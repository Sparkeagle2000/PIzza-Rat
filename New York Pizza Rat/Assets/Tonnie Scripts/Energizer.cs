using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energizer : MonoBehaviour
{
    public GameObject Bomino;
    public GameObject Papa;
    public GameObject Caesar;
    public GameObject Hut;
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
            scoreScript.score += 500;
            Bomino.GetComponent<PizzaManMover>().RunEnergizer();
            Papa.GetComponent<PizzaManMover>().RunEnergizer();
            Caesar.GetComponent<PizzaManMover>().RunEnergizer();
            Hut.GetComponent<PizzaManMover>().RunEnergizer();
            GetComponent<SpriteRenderer>().enabled = false;
            count++;
        }
    }
}
