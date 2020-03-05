using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLerp : MonoBehaviour
{
    Color lerpedColor = Color.yellow;

    // Update is called once per frame
    void Update()
    {
        lerpedColor = Color.Lerp(Color.yellow, Color.red, Mathf.PingPong(Time.time, 1));
    }
}
