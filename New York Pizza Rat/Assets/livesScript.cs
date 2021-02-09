using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesScript : MonoBehaviour
{
    public GameObject loseScreen;
    public static int lives = 9;
    public Text livesText;


    void Start()
    {
        livesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "X " + lives;
        if(lives<=0)
        {
            loseScreen.SetActive(true);
        }
    }
}
