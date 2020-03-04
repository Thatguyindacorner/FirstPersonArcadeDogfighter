using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    Text playerScore;
    public static int scoreValue = 0;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controls player's current score
        scoreValue = player.GetComponent<Fly>().score;
        playerScore.text = "Score: " + scoreValue;
    }
}
