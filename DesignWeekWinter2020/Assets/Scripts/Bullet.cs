﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 startPos;
    public float speed = 5.0f;
    public int damage = 1;

    public bool isMissile = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, startPos) > 2000)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }


}
