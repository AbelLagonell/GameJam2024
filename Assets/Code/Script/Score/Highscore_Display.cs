using UnityEngine;

public class Highscore_Display : MonoBehaviour {
    [SerializeField] private TMPro.TextMeshProUGUI text;

    private void Start() {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        string txt = "";
        foreach (int score in Stat_Tracker.Instance.currentStats.highScores) {
            txt += score + "\n";
        }

        text.text = $"High Scores:\n{txt}";
    }

}
