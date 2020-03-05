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

    float rotSpeed = 25.0f;

    private Vector3 lastAngle;

    public int score = 0;
    public int health = 5;
    public AudioSource collideSound;

    // Start is called before the first frame update
    void Start()
    {
        p_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //fly
        //p_rb.velocity = transform.forward * speed;

        float relRange = (20 - -20) / 2f;

        float offset = 20 - relRange;

        Vector3 angles = transform.eulerAngles;
        float x = ((angles.x + 540) % 360) - 180 - offset;
        float y = ((angles.y + 540) % 360) - 180 - offset;


        if (Input.GetAxis("Horizontal") > 0)
        {
            /*
            if (Mathf.Abs(y) <= relRange)
                transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
                */
            if (transform.position.x < 1000)
                transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            /*
            if (Mathf.Abs(y) <= relRange)
                transform.Rotate(new Vector3(0, -rotSpeed * Time.deltaTime, 0));
                */
            if (transform.position.x > -1000)
                transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        /*
        if (Mathf.Abs(y) > relRange)
        {
            angles.y = relRange * Mathf.Sign(y) + offset;
            transform.eulerAngles = angles;
        }
        */



        if (Input.GetAxis("Vertical") > 0 && transform.position.y < 1000)
        {
            //if (Mathf.Abs(x) <= relRange)
            Debug.Log(transform.eulerAngles.x);
            if (Mathf.Abs(x) <= relRange)
                transform.Rotate(new Vector3(rotSpeed * Time.deltaTime, 0, 0));
        }

        else if (Input.GetAxis("Vertical") < 0 && transform.position.y > -1000)
        {
            if (Mathf.Abs(x) <= relRange)
                transform.Rotate(new Vector3(-rotSpeed * Time.deltaTime, 0, 0));
        }

        if (Mathf.Abs(x) > relRange)
        {
            angles.x = relRange * Mathf.Sign(x) + offset;
            transform.eulerAngles = angles;
        }

        if (transform.position.y <= -1000 || transform.eulerAngles.x == 340)
            transform.Rotate(new Vector3(-rotSpeed * Time.deltaTime, 0, 0));

        else if (transform.position.y >= 1000 || transform.eulerAngles.x == 20)
            transform.Rotate(new Vector3(rotSpeed * Time.deltaTime, 0, 0));



        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            PlayerHud.Instance.UpdateHitUI();
            health -= 1;
            Destroy(collision.gameObject);
            collideSound.Play();

            if (health <= 0)
                SceneManager.LoadScene(0);
        }
    }
}
