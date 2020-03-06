using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerScore : MonoBehaviour
{
    Text m_playerScore;
    public static int waveNum = 1;
    public static int scoreValue = 0;

    GameObject player;
    GameObject wave;
    GameObject currentWave;
    GameObject currentScore;
    Vector3 scaleChange;


    public Vector3 m_startingScale;
    public Vector3 m_endScale;
    public AnimationCurve m_animCurve;
    public float m_powTime = .5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wave = GameObject.Find("Wave");
        currentWave = GameObject.Find("De bree");


        //playerScore = GetComponent<Text>();

        DontDestroyOnLoad(this.gameObject);

        m_playerScore = GetComponent<Text>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Fly flier = player.GetComponent<Fly>();
        //Controls player's current score
        if (flier.score != scoreValue)
        {
            scoreValue = flier.score;
            m_playerScore.text = "Score: " + scoreValue;
            if (m_startCor != null)
            {
                StopCoroutine(m_startCor);
            }
            m_startCor = StartCoroutine(StartPow());
            //print("New Score");
        }
        waveNum = currentWave.GetComponent<DebreeSpawner>().wave;
        wave.GetComponent<Text>().text = "Wave: " + waveNum;

       //**WIP, when the player scores, play this iTween** 
    // iTween.PunchScale(currentScore,iTween.Hash ("x", 3f, "y", 3f, 0, "time", 1f));
    }


    private Coroutine m_startCor;
    private IEnumerator StartPow()
    {
        m_playerScore.transform.localScale = m_startingScale;
        float timer = 0;
        while (timer < m_powTime)
        {
            timer += Time.deltaTime;
            m_playerScore.transform.localScale = Vector3.Lerp(m_startingScale, m_endScale, m_animCurve.Evaluate(timer/m_powTime));
            yield return null;
        }
        m_playerScore.transform.localScale = m_startingScale;

    }

    public int GetScore()
    {
        return scoreValue;
    }
}
