using UnityEngine;

public class EnemySpiral : MonoBehaviour {
    private float radius = 3f;
    private float speed = 1f;
    private Vector3 centerOffset = Vector3.zero;

    private Vector3 centerPoint;
    private float currentAngle;

    private void Start() {
        centerPoint = transform.position + centerOffset;
    }

    private void Update() {
        currentAngle += speed * Time.deltaTime;

        float x = Mathf.Cos(currentAngle) * radius;
        float z = Mathf.Sin(currentAngle) * radius;

        transform.position = centerPoint + new Vector3(x, z, 0f);
    }
}
