using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    Text playerScore;
    public static int scoreValue = 0;


    // Start is called before the first frame update
    void Start()
    {
        playerScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controls player's current score
        playerScore.text = "Score: " + scoreValue;
    }
}
