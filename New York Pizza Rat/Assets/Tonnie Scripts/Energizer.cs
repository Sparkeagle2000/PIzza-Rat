using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energizer : MonoBehaviour
{
    PizzaManMover pizzaman;
    private int count;

    private AudioSource source;
    // Start is called before the first frame update


    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D (Collider2D co)
    {
        if(co.name == "pizzarat"&&count==0)
        {
            source.Play();
            pizzaman =GameObject.FindGameObjectWithTag("pman").GetComponent<PizzaManMover>();
            pizzaman.RunEnergizer();
            GetComponent<SpriteRenderer>().enabled = false;
            count++;
        }
    }
}
