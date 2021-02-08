using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepperon : MonoBehaviour
{
    private int count=0;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "pizzarat"&&count==0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("ping");
            count++;
        }
    }
}
