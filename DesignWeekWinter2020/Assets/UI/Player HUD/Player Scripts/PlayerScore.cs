using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerScore : MonoBehaviour
{
    Text playerScore;
    public static int waveNum = 1;
    public static int scoreValue = 0;

    GameObject player;
    GameObject wave;
    GameObject currentWave;
    GameObject currentScore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wave = GameObject.Find("Wave");
        currentWave = GameObject.Find("De bree");

        playerScore = GetComponent<Text>();

        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Controls player's current score
        scoreValue = player.GetComponent<Fly>().score;
        waveNum = currentWave.GetComponent<DebreeSpawner>().wave;

        wave.GetComponent<Text>().text = "Wave: " + waveNum;
        playerScore.text = "Score: " + scoreValue;
       //**WIP, when the player scores, play this iTween** 
     //  iTween.PunchScale(currentScore,iTween.Hash ("x", 3f, "y", 3f, 0, "time", 1f));
    }
}
