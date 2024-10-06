using UnityEngine;

public class Cloud_Move : MonoBehaviour {
    private void FixedUpdate() {
        transform.Translate(Vector3.right * 2 * Time.deltaTime);
        if (transform.position.y <= -10) {
            Destroy(gameObject);
        }

    }

}
