using UnityEngine;

public class View_Score : MonoBehaviour {
    [SerializeField] private GameObject statsObject;
    [SerializeField] private GameObject pauseObject;
    [SerializeField] private TMPro.TextMeshProUGUI pauseText;

    public void Awake() {
        statsObject.SetActive(false);
    }

    public void viewScore() {
        gameObject.SetActive(false);
        pauseObject.SetActive(false);
        statsObject.SetActive(true);
    }

    public void backToPause() {
        gameObject.SetActive(true);
        pauseObject.SetActive(true);
        statsObject.SetActive(false);
    }

    public void Update() {
        pauseText.text = Stat_Tracker.Instance.currentStats.gameStatus;
    }

}
