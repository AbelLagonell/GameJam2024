using UnityEngine;

public class View_Score : MonoBehaviour {
    [SerializeField] private GameObject statsObject;
    [SerializeField] private GameObject pauseObject;

    public void Awake() {
        statsObject.SetActive(false);
    }

    public void viewScore() {
        gameObject.SetActive(false);
        statsObject.SetActive(true);
    }

    public void backToPause() {
        gameObject.SetActive(true);
        statsObject.SetActive(false);
    }

}
