using UnityEngine;

public class Enemy : MonoBehaviour {
    public float rotateSpeed = 1f;
    public string enemyType;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            throw new System.Exception("Object does not have a rigidbody");
        }
    }

    private void FixedUpdate() {
        rb.angularVelocity = Vector3.up * rotateSpeed;
    }

    private void OnDestroy() {
        Stat_Tracker.Instance.RecordEnemyKill(enemyType);
    }
}
