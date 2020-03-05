using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public Camera cam;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dist = transform.position - cam.transform.position;

        dist = dist * cam.nearClipPlane / dist.magnitude;
        dist += cam.transform.position;

        dist.z += 45;

        transform.position = new Vector3(transform.position.x, transform.position.y, dist.z);
    }
}
