using UnityEngine;

public class Enemy_Bullet : MonoBehaviour {
    private float speed = 15f;
    private int lifetime = 0;

    private void FixedUpdate() {
        transform.Translate(new Vector3(0, -0.5f, 0) * speed * Time.deltaTime);
        lifetime++;
        if (lifetime > 100) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<Player_Health>().DecrementHealth();
            Destroy(this.gameObject);
        }
    }
}
