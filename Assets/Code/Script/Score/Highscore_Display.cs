using UnityEngine;

public class Highscore_Display : MonoBehaviour {
    [SerializeField] private TMPro.TextMeshProUGUI text;
    public GameObject panel;

    private void Start() {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        string txt = "";
        foreach (int score in Stat_Tracker.Instance.currentStats.highScores) {
            txt += score + "\n";
        }

        text.text = $"High Scores:\n{txt}";
    }

    public void OnClick() {
        panel.SetActive(!panel.activeSelf);
    }

}
