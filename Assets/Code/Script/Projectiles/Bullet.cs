using UnityEngine;

public class Bullet : MonoBehaviour {
    private float speed = 15f;
    private int lifetime = 0;

    private void FixedUpdate() {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        lifetime++;
        if (lifetime > 200) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            other.GetComponent<Enemy>().DestroyMe();
            Destroy(this.gameObject);
        }
    }
}
