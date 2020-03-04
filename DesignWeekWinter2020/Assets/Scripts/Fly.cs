using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    float rotSpeed = 20.0f;

    Quaternion rotationX;
    Quaternion rotationY;

    private Vector3 lastAngle;

    public int score = 0;
    public int health = 5;

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


        //Mouse controls
        /*
        if (Input.mousePosition.x > Screen.width / 2)
        {
            //turn right scales
            maxAngleX = (Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2);
        }
        if (Input.mousePosition.x < Screen.width / 2)
        {
            //turn left scales
            maxAngleX = (Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2);
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
        }
        */

        /*
        //Keyboard & by proxy, joystick controls
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
        */

        float relRange = (25 - -25) / 2f;

        float offset = 25 - relRange;

        Vector3 angles = transform.eulerAngles;
        float x = ((angles.x + 540) % 360) - 180 - offset;
        float y = ((angles.y + 540) % 360) - 180 - offset;


        if (Input.GetAxis("Horizontal") > 0)
        {
            if (Mathf.Abs(y) <= relRange)
                transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (Mathf.Abs(y) <= relRange)
                transform.Rotate(new Vector3(0, -rotSpeed * Time.deltaTime, 0));
        }

        if (Mathf.Abs(y) > relRange)
        {
            angles.y = relRange * Mathf.Sign(y) + offset;
            transform.eulerAngles = angles;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            if (Mathf.Abs(x) <= relRange)
                transform.Rotate(new Vector3(rotSpeed * Time.deltaTime, 0, 0));
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            if (Mathf.Abs(x) <= relRange)
                transform.Rotate(new Vector3(-rotSpeed * Time.deltaTime, 0, 0));
        }

        if (Mathf.Abs(x) > relRange)
        {
            angles.x = relRange * Mathf.Sign(x) + offset;
            transform.eulerAngles = angles;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            health -= 1;
            Destroy(collision.gameObject);

            if (health <= 0)
                SceneManager.LoadScene(0);
        }
    }
}
