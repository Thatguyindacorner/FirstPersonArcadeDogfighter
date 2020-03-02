using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{

    Rigidbody p_rb;
    public float speed;
    float maxAngleX;
    float maxAngleY;
    Vector3 rotate;

    float lastX;
    float lastY;
    float dirTimerX;
    float dirTimerY;

    // Start is called before the first frame update
    void Start()
    {
        p_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //fly
        p_rb.velocity = transform.forward * speed;

        
        

        //steer

        //hold rotation to become new direction
        if (maxAngleX == lastX)
        {
            if (dirTimerX == 0)
            {
                dirTimerX = Time.time;
            }
            if (Time.time - dirTimerX > 2)
            {
                //lock rotation
                transform.forward = new Vector3(maxAngleX, transform.forward.y, transform.forward.z);
                if (Input.GetKeyDown("space"))
                {
                    dirTimerX = 0;
                }
            }
        }
        if (maxAngleY == lastY)
        {
            if (dirTimerY == 0)
            {
                dirTimerY = Time.time;
            }
            if (Time.time - dirTimerY > 2)
            {
                //lock rotation
                transform.forward = new Vector3(transform.forward.x, maxAngleY, transform.forward.z);
                if (Input.GetKeyDown("space"))
                {
                    dirTimerY = 0;
                }
            }
        }

        if (Input.mousePosition.x > Screen.width / 2)
        //if ()
        {
            //turn right scales
            //transform.forward.
            //  transform.rotation.SetLookRotation()
            maxAngleX = (Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2);
        }
        if (Input.mousePosition.x < Screen.width / 2)
        {
            //turn left scales
            maxAngleX = (Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2);
           // maxAngleX = 1 / (Screen.width / 2) / (Input.mousePosition.x - Screen.width / 2);
        }
        if (Input.mousePosition.y > Screen.height / 2)
        {
            //turn up scales
            maxAngleY = (Input.mousePosition.y - Screen.height / 2) / (Screen.height / 2);
        }
        if (Input.mousePosition.y < Screen.height / 2)
        {
            //turn down scales
            maxAngleY = (Input.mousePosition.y - Screen.height / 2) / (Screen.height / 2);
            //maxAngleY = (Screen.height / 2) / (Input.mousePosition.y - Screen.height / 2);
            
        }
        rotate += new Vector3(maxAngleX, maxAngleY, 1);
       // print(rotate);
        Quaternion rotationX = Quaternion.AngleAxis(Mathf.Rad2Deg * maxAngleX, Vector3.up);
        
print(rotationX.eulerAngles + " X");
        Quaternion rotationY = Quaternion.AngleAxis(Mathf.Rad2Deg * maxAngleY, Vector3.right);
//print(rotationY.eulerAngles + " Y");

        if (Input.mousePosition.y >= Screen.height || Input.mousePosition.y <= Screen.height)
        {
            
        }
        if (Input.mousePosition.x >= Screen.width || Input.mousePosition.x <= Screen.width)
        {
           
        }

        transform.rotation = rotationX * rotationY;
        lastX = transform.rotation.x;
        //print(transform.rotation.x + " Xvs " + maxAngleX);
        lastY = transform.rotation.y;
        //print(transform.rotation.y + " Yvs " + max);
        print(transform.forward + " vs " + new Vector3(maxAngleX, maxAngleY, 1));
    }
}
