using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiagonalDown : MonoBehaviour
{

    public float speedDown = 3;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speedDown * Time.deltaTime);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
    }
}