using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour
{
    private int count;
    private int fruit;
    public GameObject onion; 
    public GameObject pepper;
    public GameObject shroom;
    public GameObject pina;
    private bool taco=false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        while(taco==false)
        {
            count=Random.Range(6,10);
            fruit=Random.Range(1,4);
            yield return new WaitForSeconds(count);
            if(fruit==1)
            {
                Instantiate(onion, new Vector2(0, 0), Quaternion.identity);
            }
            if(fruit==2)
            {
                Instantiate(pepper, new Vector2(0, 0), Quaternion.identity);
            }
            if(fruit==3)
            {
                Instantiate(shroom, new Vector2(0, 0), Quaternion.identity);
            }
            if(fruit==4)
            {
                Instantiate(pina, new Vector2(0, 0), Quaternion.identity);
            }
        }

    }

}

