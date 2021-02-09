using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pepperon : MonoBehaviour
{
    private int count = 0;

    private AudioSource source;


    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pizzarat" && count == 0)
        {
            scoreScript.pepperoni++;
            Debug.Log(scoreScript.pepperoni);
            source.Play();
            scoreScript.score += 100;
            GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("ping");
            count++;
        }
    }
}