using UnityEngine;

public class Lazer : MonoBehaviour {
    private int lifetime = 0;

    private void FixedUpdate() {
        lifetime++;
        if (lifetime > 50) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
        }

    }
}
