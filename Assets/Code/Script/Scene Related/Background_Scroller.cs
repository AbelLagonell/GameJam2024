using System.Collections.Generic;
using UnityEngine;

public class Background_Scroller : MonoBehaviour {
    [SerializeField] private GameObject background;
    private List<Transform> childTransform = new List<Transform>();

    private Vector3 startPosition;
    private float time = 0;
    private float timeInBetween = 4f;

    private void Start() {
        startPosition = transform.position;

    }

    private void FixedUpdate() {
        time += Time.deltaTime;
        if (time > timeInBetween) {
            Instantiate(background, startPosition + Vector3.right * Random.Range(-3f, 5f), transform.rotation);
            time = 0;
        }
    }

}
