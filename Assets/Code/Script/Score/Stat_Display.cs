using UnityEngine;

public class Stat_Display : MonoBehaviour {

    [SerializeField] private TMPro.TextMeshProUGUI score;
    [SerializeField] private TMPro.TextMeshProUGUI kills;
    [SerializeField] private TMPro.TextMeshProUGUI playTime;
    [SerializeField] private TMPro.TextMeshProUGUI bulletsBlocked;

    [SerializeField] private TMPro.TextMeshProUGUI lavisKills;
    [SerializeField] private TMPro.TextMeshProUGUI surgeKills;

    [SerializeField] private TMPro.TextMeshProUGUI blackBlocks;
    [SerializeField] private TMPro.TextMeshProUGUI whiteBlocks;

    private void Awake() {
        Debug.Log("Loaded Stats");
        Stat_Tracker stats = Stat_Tracker.Instance;
        score.text = $"Score: {stats.currentStats.totalScore}";
        kills.text = $"Total Kills: {stats.currentStats.enemiesKilled}";
        playTime.text = $"Total Playtime: {stats.currentStats.playTime}";
        bulletsBlocked.text = $"Total Bullet Blocked: {stats.currentStats.bulletsBlocked}";

        stats.currentStats.enemyTypeKills.TryGetValue("Lavis", out int enemKills);
        lavisKills.text = $"Lavis Kills: {enemKills}";
        stats.currentStats.enemyTypeKills.TryGetValue("Surge", out enemKills);
        surgeKills.text = $"Surge Kills: {enemKills}";
        stats.currentStats.bulletTypeBlocked.TryGetValue("Black", out int bulBlock);
        blackBlocks.text = $"Black Bullets: {bulBlock}";
        stats.currentStats.bulletTypeBlocked.TryGetValue("White", out bulBlock);
        whiteBlocks.text = $"White Bullets: {bulBlock}";

    }
}
