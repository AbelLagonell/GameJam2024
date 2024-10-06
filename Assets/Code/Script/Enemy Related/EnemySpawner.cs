using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject[] formations;

    public float timeToSpawn, spawnCountdown, formationSend;
    // Start is called before the first frame update
    void Start() {
        spawnCountdown = timeToSpawn;
        formationSend = 1;
    }

    // Update is called once per frame
    void Update() {
        spawnCountdown -= Time.deltaTime;
        if (formationSend > 3) {
            formationSend = 1;
        }

        if (spawnCountdown <= 0) {
            spawnCountdown = timeToSpawn;
            if (formationSend == 1) {
                Instantiate(formations[0], new Vector3(0, 8, 0), Quaternion.identity);
            } else if (formationSend == 2) {
                Instantiate(formations[1], new Vector3(-6, 6, 0), Quaternion.identity);
            } else if (formationSend == 3) {
                Instantiate(formations[3], new Vector3(6, 6, 0), Quaternion.identity);
            }
            formationSend++;
        }
    }
}
