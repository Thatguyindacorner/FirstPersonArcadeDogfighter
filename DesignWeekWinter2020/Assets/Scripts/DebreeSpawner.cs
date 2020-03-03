using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebreeSpawner : MonoBehaviour
{
    public GameObject[] choices;

    public GameObject player;
    Vector3 startPos;

    int wave;

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
        /*
        int index; 
        index = Random.Range(0, 3);
        return choices[index];
        */
        return choices[0];
    }

    void LevelTraker()
    {
        if (player.GetComponent<Transform>().position.z - startPos.z > 7500)
        {
            print(player.GetComponent<Transform>().position.z - startPos.z);
            wave += 1;
            startPos = player.GetComponent<Transform>().position;
            SpawnThings();
        }
    }

    int SpawnNum()
    {
        return wave * 100;
    }

    void SpawnThings()
    {
        int n = SpawnNum();
        while (n > 0)
        {
            GameObject thing = ChooseThing();
            Instantiate(thing, new Vector3(Random.Range(player.GetComponent<Transform>().position.x, 2000 + player.GetComponent<Transform>().position.x), Random.Range(player.GetComponent<Transform>().position.y - 1000, 1000 + player.GetComponent<Transform>().position.y), Random.Range(player.GetComponent<Transform>().position.z + 2500, player.GetComponent<Transform>().position.z + 10000)), Quaternion.Euler(0,0,0));
            n--;
            print(Random.Range(player.GetComponent<Transform>().position.x - 1000, 1000 + player.GetComponent<Transform>().position.x));
        }
        
    }
}
