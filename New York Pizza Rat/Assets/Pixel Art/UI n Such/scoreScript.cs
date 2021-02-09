using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreScript : MonoBehaviour
{


    public static int score = 0;
    public static int pepperoni=0;
    public Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE " + "" + score;
        if(pepperoni==99)
        {
            SceneManager.LoadScene("Level2");
        }
        if(pepperoni==198)
        {
            
        }
    }
}
