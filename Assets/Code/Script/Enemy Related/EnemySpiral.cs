using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpiral : MonoBehaviour
{
    public float speed = 3;
    public float negative = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * negative * speed * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        transform.Rotate(0.0f, 0.0f, 1.5f, Space.Self);
    }
}
