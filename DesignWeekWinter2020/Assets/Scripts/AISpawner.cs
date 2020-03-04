﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    Vector3 startPos;

    private int wave;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        startPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LevelTracker();
    }

    void LevelTracker()
    {
        if (player.GetComponent<Transform>().position.z - startPos.z > 7500)
        {
            print(player.GetComponent<Transform>().position.z - startPos.z);
            wave += 1;
            startPos = player.transform.position;
            SpawnThings();
        }
    }

    void SpawnThings()
    {
        int n = wave;
        while (n > 0)
        {
            Instantiate(enemy, new Vector3(Random.Range(player.GetComponent<Transform>().position.x, 2000 + player.GetComponent<Transform>().position.x), Random.Range(player.GetComponent<Transform>().position.y - 1000, 1000 + player.GetComponent<Transform>().position.y), Random.Range(player.GetComponent<Transform>().position.z + 2500, player.GetComponent<Transform>().position.z + 10000)), Quaternion.Euler(0, 0, 0));
            n--;
            print(Random.Range(player.GetComponent<Transform>().position.x - 1000, 1000 + player.GetComponent<Transform>().position.x));
        }
    }
}