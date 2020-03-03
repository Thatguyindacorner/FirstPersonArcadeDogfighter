using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{

    Rigidbody p_rb;
    [Range(100, 10000)]
    public float speed;
    
    float maxAngleX;
    float maxAngleY;

    float lastX;
    float lastY;
    string dirX;
    string dirY;

    Quaternion rotationX;
    Quaternion rotationY;

    private Vector3 lastAngle;

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

        /*

        if (Input.mousePosition.x > Screen.width / 2)
        {
            //turn right scales
            maxAngleX = (Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2);
            if (dirTimerX == 0)
            {
                dirTimerX = Time.time;
            }
        }
        if (Input.mousePosition.x < Screen.width / 2)
        {
            //turn left scales
            maxAngleX = (Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2);
            if (dirTimerX == 0)
            {
                dirTimerX = Time.time;
            }
        }
        if (Input.mousePosition.y > Screen.height / 2)
        {
            //turn up scales
            maxAngleY = (Input.mousePosition.y - Screen.height / 2) / (Screen.height / 2);
            if (dirTimerY == 0)
            {
                dirTimerY = Time.time;
            }
        }
        if (Input.mousePosition.y < Screen.height / 2)
        {
            //turn down scales
            maxAngleY = (Input.mousePosition.y - Screen.height / 2) / (Screen.height / 2);
            if (dirTimerY == 0)
            {
                dirTimerY = Time.time;
            }
            
        }

        if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            dirTimer = Time.time;
            transform.forward = GetLastAngle();
        }
       
        
        */


        if (Input.GetAxis("Horizontal") > 0)
        {
           // if (Input.GetAxis("Horizontal") > lastX)
            {
                maxAngleX = Input.GetAxis("Horizontal");
                dirX = "right";
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
          // if (Input.GetAxis("Horizontal") < lastX)
            {
                maxAngleX = Input.GetAxis("Horizontal");
                dirX = "left";
            } 
        }


        if (dirX == "right")
        {
            if (lastX < maxAngleX)
            {
                lastX = maxAngleX;
            }
        }
        else if (dirX == "left")
        {
            if (lastX > maxAngleX)
            {
                lastX = maxAngleX;
            }
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            //if (Input.GetAxis("Vertical") > lastY)
            {
                maxAngleY = Input.GetAxis("Vertical");
                dirY = "down";
            }
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
         //  if (Input.GetAxis("Vertical") < lastY)
            {
                maxAngleY = Input.GetAxis("Vertical");
                dirY = "up";
            }
        }


        if (dirY == "down")
        {
            if (lastY < maxAngleY)
            {
                lastY = maxAngleY;
            }
        }
        else if (dirY == "up")
        {
            if (lastY > maxAngleY)
            {
                lastY = maxAngleY;
            }
        }

        rotationX = Quaternion.AngleAxis(Mathf.Rad2Deg * maxAngleX, Vector3.up);
        rotationY = Quaternion.AngleAxis(Mathf.Rad2Deg * maxAngleY, Vector3.right);


        p_rb.MoveRotation(rotationX * rotationY);
    }
}
