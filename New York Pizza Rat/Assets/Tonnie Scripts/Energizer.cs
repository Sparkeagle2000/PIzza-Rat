using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energizer : MonoBehaviour
{
    PizzaManMover pizzaman;
    // Start is called before the first frame update
    void OnTriggerEnter2D (Collider2D co)
    {
        if(co.name == "pizzarat")
        {
            pizzaman=GameObject.FindGameObjectWithTag("pizzaman").GetComponent<PizzaManMover>();
            pizzaman.RunEnergizer();
            Destroy(this.GameObject);
        }
    }
}
