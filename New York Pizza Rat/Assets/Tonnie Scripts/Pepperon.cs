using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepperon : MonoBehaviour
{
    private int count=0;

    private AudioSource source;


    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "pizzarat"&&count==0)
        {
            source.Play();

            GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("ping");
            count++;
        }
    }
}
