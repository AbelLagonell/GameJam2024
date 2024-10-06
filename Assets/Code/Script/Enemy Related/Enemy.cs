using UnityEngine;

public class Enemy : MonoBehaviour {
    private Rigidbody rb;
    private float volume = 1f;

    public float rotateSpeed = 1f;
    public string enemyType;
    public AudioSource audioSource;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            throw new System.Exception("Object does not have a rigidbody");
        }
    }

    private void FixedUpdate() {
        rb.angularVelocity = Vector3.up * rotateSpeed;
    }

    public void DestroyMe() {
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position, volume);
        if (Stat_Tracker.Instance != null) Stat_Tracker.Instance.RecordEnemyKill(enemyType);
        Destroy(gameObject);
    }
}
