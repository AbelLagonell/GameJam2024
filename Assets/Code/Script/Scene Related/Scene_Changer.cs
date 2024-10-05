using UnityEngine;

public class Scene_Changer : MonoBehaviour {
    public void ChangeScene(int sceneIndex) {
        Scene_Controller.Instance.LoadScene(sceneIndex);
    }
}
