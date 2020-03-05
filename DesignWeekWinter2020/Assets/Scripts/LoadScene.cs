using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
 
   // public AudioSource BellRing;

    // Update is called once per frame
    public void PlayGame()
    {
        print("ClickMe");
        SceneManager.LoadScene("UI Scene");
       
    }
}
