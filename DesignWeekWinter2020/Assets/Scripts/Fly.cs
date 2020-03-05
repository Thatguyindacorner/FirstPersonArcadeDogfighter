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
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (transform.position.x < 1000)
                transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (transform.position.x > -1000)
                transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            if (transform.position.y < 1000)
                transform.Translate(0, speed * Time.deltaTime, 0);
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            if (transform.position.y > -1000)
                transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            PlayerHud.Instance.UpdateHitUI();
            health -= 1;
            collideSound.Play();
            Destroy(collision.gameObject);
            

            if (health <= 0)
                SceneManager.LoadScene(0);
        }
    }
}
