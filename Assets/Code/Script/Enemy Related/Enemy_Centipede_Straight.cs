using UnityEngine;

public class Enemy_Centipede_Straight : MonoBehaviour {
    public float speed = 3;
    public int direction = 1;

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
        if (transform.position.x > 5) direction = -1;
        if (transform.position.x < -5) direction = 1;
    }
}