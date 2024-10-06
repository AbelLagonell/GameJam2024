using UnityEngine;

public class Enemy : MonoBehaviour {
    private Rigidbody rb;
    private float volume = .5f;

    public float rotateSpeed = 1f;
    public float timeBetweenShots = 1f;
    public float timer;
    public string enemyType;
    public AudioSource audioSource;
    public GameObject bullet;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            throw new System.Exception("Object does not have a rigidbody");
        }
    }

    private void FixedUpdate() {
        rb.angularVelocity = Vector3.up * rotateSpeed;
        timer += Time.deltaTime;
        if (timer > timeBetweenShots) {
            Instantiate(bullet, transform.position, Quaternion.identity);
            timer = 0;
        }

        if (transform.position.y < -5) Destroy(gameObject);
    }

    public void DestroyMe() {
        AudioSource.PlayClipAtPoint(audioSource.clip, new Vector3(0, 1, -9), volume);
        if (Stat_Tracker.Instance != null) {
            Stat_Tracker.Instance.AddScore(10);
            Stat_Tracker.Instance.RecordEnemyKill(enemyType);
        }
        Destroy(gameObject);
    }
}
