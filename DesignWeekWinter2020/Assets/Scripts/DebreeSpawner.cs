using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebreeSpawner : MonoBehaviour
{
    public GameObject[] choices;

    public GameObject player;
    Vector3 startPos;

    public int wave;

    private bool isAsteroid = false;
    private bool isWall = false;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        startPos = player.GetComponent<Transform>().position;
        SpawnThings();
    }

    // Update is called once per frame
    void Update()
    {
        LevelTraker();
    }

    GameObject ChooseThing()
    {
        isWall = false;

        int gen = Random.Range(0, 10);
        if (gen < 2)
        {
            isAsteroid = false;
            return choices[2]; //mine
        }

        else if (gen >= 2 && gen < 4)
        {
            isAsteroid = false;
            isWall = true;
            return choices[1]; //wall
        }

        else
        {
            isAsteroid = true;
            return choices[0]; //asteroid
        }
    }

    void LevelTraker()
    {
        if (player.GetComponent<Transform>().position.z - startPos.z > 5500)
        {
            wave += 1;
            startPos = player.GetComponent<Transform>().position;
            setPlayerSpeed();
            SpawnThings();
        }
    }

    int SpawnNum()
    {
        return wave * 35;
    }

    void setPlayerSpeed()
    {
        player.GetComponent<Fly>().speed += (wave * 2);
    }

    void SpawnThings()
    {
        int n = SpawnNum();
        while (n > 0)
        {
            GameObject thing = ChooseThing();
            GameObject spwn = Instantiate(thing, new Vector3(Random.Range(player.GetComponent<Transform>().position.x - 1500, 1500 + player.GetComponent<Transform>().position.x), Random.Range(player.GetComponent<Transform>().position.y - 1000, 1000 + player.GetComponent<Transform>().position.y), Random.Range(player.GetComponent<Transform>().position.z + 2500, player.GetComponent<Transform>().position.z + 10000)), Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)));

            if (isAsteroid)
                spwn.transform.localScale = new Vector3(Random.Range(2, 4), Random.Range(2, 4), Random.Range(2, 4));

            else if (isWall)
                spwn.transform.eulerAngles = Vector3.zero;

            n--;
        }
    }
}
