using System;
using System.IO;
using UnityEngine;

public class Stat_Tracker : MonoBehaviour {
    public static Stat_Tracker Instance { get; private set; }

    private const int MAX_HIGH_SCORES = 5;

    private string saveFilePath;

    public Game_Stats currentStats = new Game_Stats();
    public event Action<int> onScoreChanged;
    public event Action<int> onEnemyKilled;
    public event Action<int> onBulletBlocked;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeSaveFilePath();
        LoadStats();
    }

    private void Update() {
        currentStats.playTime += Time.deltaTime;
    }

    public void AddScore(int points) {
        currentStats.totalScore += points;
        onScoreChanged?.Invoke(currentStats.totalScore);
        SaveStats();
    }
    public void RecordBulletBlock(string bulletType = "generic") {
        currentStats.bulletsBlocked++;

        if (!currentStats.bulletTypeBlocked.ContainsKey(bulletType)) {
            currentStats.bulletTypeBlocked[bulletType] = 0;
        }
        currentStats.bulletTypeBlocked[bulletType]++;

        onBulletBlocked?.Invoke(currentStats.bulletsBlocked);
        SaveStats();
    }

    public void RecordEnemyKill(string enemyType = "generic") {
        currentStats.enemiesKilled++;

        if (!currentStats.enemyTypeKills.ContainsKey(enemyType)) {
            currentStats.enemyTypeKills[enemyType] = 0;
        }
        currentStats.enemyTypeKills[enemyType]++;

        onEnemyKilled?.Invoke(currentStats.enemiesKilled);
        SaveStats();
    }

    public void AddHighScore(int score) {
        currentStats.highScores.Add(score);
        currentStats.highScores.Sort((a, b) => b.CompareTo(a)); // Sort descending

        if (currentStats.highScores.Count > MAX_HIGH_SCORES) {
            currentStats.highScores = currentStats.highScores.GetRange(0, MAX_HIGH_SCORES);
        }

        SaveStats();
    }

    private void InitializeSaveFilePath() {
        saveFilePath = Path.Combine(Application.persistentDataPath, "gamestats.json");
    }

    private void LoadStats() {
        try {
            if (File.Exists(saveFilePath)) {
                string jsonData = File.ReadAllText(saveFilePath);
                currentStats = JsonUtility.FromJson<Game_Stats>(jsonData);
                Debug.Log("Game stats loaded successfully");
            } else {
                Debug.Log("No save file found, starting with fresh stats");
            }
        }
        catch (Exception e) {
            Debug.LogError($"Failed to load game stats: {e.Message}");
        }
    }

    private void SaveStats() {
        try {
            string jsonData = JsonUtility.ToJson(currentStats, true);
            File.WriteAllText(saveFilePath, jsonData);
            Debug.Log("Game stats saved successfully");
        }
        catch (Exception e) {
            Debug.LogError($"Failed to save game stats: {e.Message}");
        }
    }

    private void resetStats() {
        currentStats = new Game_Stats();
        SaveStats();
    }

    public void resetCurrentStats() {
        System.Collections.Generic.List<int> hs = currentStats.highScores;
        currentStats = new Game_Stats();
        currentStats.highScores = hs;
        SaveStats();
    }
}
