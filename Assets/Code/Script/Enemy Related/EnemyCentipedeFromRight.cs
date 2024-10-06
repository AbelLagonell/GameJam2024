using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCentipedeFromRight : MonoBehaviour
{
    public float speed = 3;
    public float negative = -1;
    public bool flip = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left * speedDown * Time.deltaTime);
        transform.Translate(Vector3.right * negative * speed * Time.deltaTime);
        if(transform.position.x < -4.5 && flip == false) { //upper Left corner (already at upper right when spawning)
            transform.Rotate(0.0f, 0.0f, 90f, Space.Self); //rotate CCW
            flip = true; //do it once (would happen twice since changing to vertical movement doesnt affect horz position)
        } 
        if (transform.position.y < -3 && flip == true) { //bottom left
            transform.Rotate(0.0f, 0.0f, 90f, Space.Self); //again
            flip = false;
        }
        if (transform.position.y < -3 && transform.position.x > 1) { //goes past bottom mid, comes back up
            transform.Rotate(0.0f, 0.0f, 90f, Space.Self); //again
        }
    }
}