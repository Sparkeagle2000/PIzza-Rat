using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        
    }

 
    public void LoadScene(string Prototype)
    {
        scoreScript.score = 0;
        livesScript.lives = 9;
        scoreScript.pepperoni=0;
        SceneManager.LoadScene("Prototype");
    }
}
