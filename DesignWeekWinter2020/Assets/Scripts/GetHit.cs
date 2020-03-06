using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetHit : MonoBehaviour
{

    int score;

    public void GameOver(int yourScore)
    {
        score = yourScore;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(2);
    }

    public int GetScore()
    {
        return score;
    }
    

}
