using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //private Vector2 dest; // = Vector2.zero;
    //Rigidbody2D rb;
    Vector2 dest = Vector2.zero;

    void Start() {
        //dest = transform.position;
        //rb=GetComponent<Rigidbody2D>();
       // dest = rb.position;
       dest = transform.position;
    }

    void FixedUpdate() {
       
       // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // Check for Input if not moving
        
            if (Input.GetKey(KeyCode.UpArrow))
                dest = (Vector2)transform.position + (Vector2.up*speed);
            if (Input.GetKey(KeyCode.RightArrow))
                dest = (Vector2)transform.position + (Vector2.right*speed);
            if (Input.GetKey(KeyCode.DownArrow))
                dest = (Vector2)transform.position - (Vector2.up*speed);
            if (Input.GetKey(KeyCode.LeftArrow))
                dest = (Vector2)transform.position - (Vector2.right*speed);
            if (Input.GetKey(KeyCode.W))
                dest = (Vector2)transform.position + (Vector2.up*speed);
            if (Input.GetKey(KeyCode.D))
                dest = (Vector2)transform.position + (Vector2.right*speed);
            if (Input.GetKey(KeyCode.S))
                dest = (Vector2)transform.position - (Vector2.up*speed);
            if (Input.GetKey(KeyCode.A))
                dest = (Vector2)transform.position - (Vector2.right*speed);
        
       
       
       
        /*if (Input.GetAxis("Horizontal")<0)
            dest = Vector2.left;

        if (Input.GetAxis("Horizontal")>0)
            dest = Vector2.right;

        if (Input.GetAxis("Vertical")<0)
            dest = Vector2.down;
        
        if (Input.GetAxis("Vertical")>0)
            dest = Vector2.up;

        rb.velocity = dest * speed;

        transform.up = dest;
        */
        


        
        

    // Animation Parameters
    //    Vector2 dir = dest - (Vector2)transform.position;
    //    GetComponent<Animator>().SetFloat("DirX", dir.x);
     //   GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
}
