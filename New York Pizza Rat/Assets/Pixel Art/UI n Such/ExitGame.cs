using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
 
    void Start()
    {
        
    }

  
    public void Quit()
    {
        
        Application.Quit();

        //remove this one before turning in game - Gary
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
