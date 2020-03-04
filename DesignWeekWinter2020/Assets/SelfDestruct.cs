using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifespan = 1;
    void Start()
    {
        Invoke("DestroySelf", lifespan);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
