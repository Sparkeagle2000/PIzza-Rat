using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energizer : MonoBehaviour
{
    PizzaManMover pizzaman;
    private int count;
    // Start is called before the first frame update
    void OnTriggerEnter2D (Collider2D co)
    {
        if(co.name == "pizzarat"&&count==0)
        {
            pizzaman=GameObject.FindGameObjectWithTag("pizzaman").GetComponent<PizzaManMover>();
            pizzaman.RunEnergizer();
            GetComponent<SpriteRenderer>().enabled = false;
            count++;
        }
    }
}
