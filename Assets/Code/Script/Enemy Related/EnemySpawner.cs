using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject[] formations;
    private int waveCount = 1;

    public float timeToSpawn, spawnCountdown, formationSend;
    // Start is called before the first frame update
    void Start() {
        spawnCountdown = timeToSpawn;
        formationSend = 1;
    }

    // Update is called once per frame
    void Update() {
        spawnCountdown -= Time.deltaTime * waveCount;
        if (formationSend > 3) {
            formationSend = 1;
            waveCount++;
        }

        if (spawnCountdown <= 0) {
            spawnCountdown = timeToSpawn;
            if (formationSend == 1) {
                Instantiate(formations[0], new Vector3(0, 0, 0) + transform.position, Quaternion.identity);
            }
            if (formationSend == 2) {
                Instantiate(formations[1], new Vector3(-6, 0, 0) + transform.position, Quaternion.identity);
            }
            if (formationSend == 3) {
                Instantiate(formations[2], new Vector3(0, 0, 0) + transform.position, Quaternion.identity);
            }
            formationSend++;
        }
    }
}
