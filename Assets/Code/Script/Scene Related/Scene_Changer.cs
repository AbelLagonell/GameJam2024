using UnityEngine;

public class Scene_Changer : MonoBehaviour {
    public void ChangeScene(int sceneIndex) {
        Scene_Controller.Instance.LoadScene(sceneIndex);
        if (sceneIndex == 1) { Stat_Tracker.Instance.resetCurrentStats(); }
    }
}
