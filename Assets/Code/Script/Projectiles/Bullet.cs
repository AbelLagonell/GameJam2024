using UnityEngine;

public class Bullet : MonoBehaviour {
    private float speed = 15f;
    private int lifetime = 0;

    private void FixedUpdate() {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        lifetime++;
        if (lifetime > 100) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision other) {
        for (int i = 0; i < 2; i++) {
            if (other.GetContact(i).otherCollider.gameObject.tag == "Enemy") {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Debug.Log("Works");
            }
        }
    }
}
