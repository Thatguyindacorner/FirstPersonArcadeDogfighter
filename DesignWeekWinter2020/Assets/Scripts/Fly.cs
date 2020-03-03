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
    string dirX;
    string dirY;
    float dirTimerX;
    float dirTimerY;
    float dirTimer;

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
        //p_rb.velocity = transform.forward * speed * Time.deltaTime;
        transform.Translate(transform.forward * speed * Time.deltaTime);



        //steer

        //hold rotation to become new direction



        if (Time.time - dirTimerX > 2 && dirTimerX != 0)
        {
            //lock rotation
            transform.forward = (rotationX * rotationY).eulerAngles.normalized;
            if (Input.GetKeyDown("space"))
            {
                dirTimerX = 0;
            }
        }
        

        if (Time.time - dirTimerY > 2 && dirTimerY != 0)
        {
            //lock rotation
            transform.forward = (rotationX * rotationY).eulerAngles.normalized;
            if (Input.GetKeyDown("space"))
            {
                dirTimerY = 0;
            }
        }
        

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
            maxAngleX = Input.GetAxis("Horizontal");
            dirX = "right";
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            maxAngleX = Input.GetAxis("Horizontal");
            dirX = "left";
        }
        else
        {
            //turn Cam
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
            maxAngleY = -Input.GetAxis("Vertical");
            dirY = "down";
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            maxAngleY = -Input.GetAxis("Vertical");
            dirY = "up";
        }
        else
        {
            //turn Cam
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
        

        rotate += new Vector3(maxAngleX, maxAngleY, 1);
       // print(rotate);

        rotationX = Quaternion.AngleAxis(Mathf.Rad2Deg * maxAngleX, Vector3.up);
        rotationY = Quaternion.AngleAxis(Mathf.Rad2Deg * maxAngleY, Vector3.right);

        if (Time.time - dirTimer > 2)
        {
            SetLastAngle(rotationX, rotationY);
            dirTimer = 0;
        }


        if (Input.mousePosition.y >= Screen.height || Input.mousePosition.y <= Screen.height)
        {
            transform.forward = (rotationX * rotationY).eulerAngles.normalized;
        }
        if (Input.mousePosition.x >= Screen.width || Input.mousePosition.x <= Screen.width)
        {
            transform.forward = (rotationX * rotationY).eulerAngles.normalized;
        }
        
        transform.rotation = rotationX * rotationY;
        print(transform.forward.normalized + " vs " + new Vector3 (lastX, lastY, 1));
    }

    Vector3 GetLastAngle()
    {
        return lastAngle;
    }
    void SetLastAngle(Quaternion X, Quaternion Y)
    {
        lastAngle = (X * Y).eulerAngles + transform.forward;
    }

}
