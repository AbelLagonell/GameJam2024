using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCentipedeFromRight : MonoBehaviour
{
    public float speed = 3;
    public float negative = -1;
    public bool flip = false;
    public bool startMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startMove){
            transform.Translate(Vector3.forward * negative * speed * Time.deltaTime);
        }

        if(transform.position.x < -4.5 && flip == false) { //upper right corner (already at upper left when spawning)
            transform.Translate(Vector3.down * speed * Time.deltaTime); //Rotate CW
            //do it once (would happen twice since changing to vertical movement doesnt affect horz position)
            startMove = false;
        } 
        if (transform.position.y < -3 && flip == false) { //bottom right
            speed = speed * -1;
            flip = true;
        }
        if (flip) {
            transform.Translate(Vector3.forward * negative * speed * Time.deltaTime);
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        
        if (transform.position.y > 7) {
            Destroy(this.gameObject);
        }
    }
}