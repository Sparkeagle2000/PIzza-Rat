using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    private int count = 0;
    private float time=3.0f;

    private AudioSource source;


    // Start is called before the first frame update
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        Timer();
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pizzarat" && count == 0)
        {
            source.Play();
            scoreScript.score += 100;
            GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("ping");
            count++;
        }
    }
    void Timer ()
    {
        time-=Time.deltaTime;
        if(time<=0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            count++;
        }
    }
}
