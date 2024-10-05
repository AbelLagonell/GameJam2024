using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controller : MonoBehaviour {
    public static Scene_Controller Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public async void LoadScene(int sceneIndex) {
        var scene = SceneManager.LoadSceneAsync(sceneIndex);
        //Loading Bar? v
        //scene.allowSceneActivation = false;
    }

}
