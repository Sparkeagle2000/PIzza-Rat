using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public Transform tploc;
    public GameObject dude;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "pizzarat")
            dude.transform.position=tploc.transform.position;          
    }
}
