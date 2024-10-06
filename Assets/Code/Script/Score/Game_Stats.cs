using System;
using System.Collections.Generic;

[Serializable]
public class Game_Stats {
    public int totalScore;
    public int enemiesKilled;
    public int bulletsBlocked;
    public float playTime;
    public Dictionary<string, int> enemyTypeKills = new Dictionary<string, int>();
    public Dictionary<string, int> bulletTypeBlocked = new Dictionary<string, int>();
    public List<int> highScores = new List<int>();
}
