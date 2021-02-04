using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepperon : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D co) {
        if (co.name == "pizzarat")
            Destroy(gameObject);
    }
}
