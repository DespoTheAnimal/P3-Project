using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerBehaviour : MonoBehaviour
{
    //Gradually increase speed
    public static float forwardMovement = 10f;
    private float currentSpeed = 0f;
    private float minSpeed;
    private float maxSpeed = 50f;
    private float acceleration = 10f;
    private float deceleration = 10f;
    private float timeForSpeed;
    private int accelerationTime = 60;


    private Rigidbody rb;
    private static int movementSpeed = 5;
    private float distanceToGround = 1f;
    private float gravityFactor = 10f;
    private int jumpHeight = 10;

    public static int lives = 3;
    public TextMeshProUGUI text;
    public GameObject[] Hearts;
    private int score;

    void Start()
    {
        timeForSpeed = 0f;
        minSpeed = currentSpeed;
        lives = 3;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (lives < 1)
        {
            Destroy(Hearts[0].gameObject);
            Destroy(Hearts[1].gameObject);
            Destroy(Hearts[2].gameObject);
        }
        else if (lives < 2)
        {
            Destroy(Hearts[1].gameObject);
            Destroy(Hearts[2].gameObject);
        }
        else if (lives < 3)
        {
            Destroy(Hearts[2].gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Jump())
        {
            rb.AddForce(new Vector3(0, jumpHeight * rb.mass, 0), ForceMode.Impulse);
        }

        LoseCondition();
        IncreaseSpeed();
    }

    private void FixedUpdate()
    {
        Movement();
        rb.AddForce(new Vector3(0, -1, 0) * gravityFactor, ForceMode.Acceleration);
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 pos = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f), transform.position.y, transform.position.z);       
        rb.MovePosition(pos + new Vector3(horizontal * movementSpeed, 0f, currentSpeed) * Time.deltaTime);

    }

    private bool Jump()
    {
        if(Physics.Raycast(transform.position, Vector3.down, distanceToGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void LoseCondition()
    {
        if (lives <= 0)
        {
            PlayerPrefs.SetInt("NewScore", score);
            SceneManager.LoadScene("YouDied");
        }
    }

    void IncreaseSpeed()
    {
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, timeForSpeed / accelerationTime);
        timeForSpeed += Time.deltaTime;
    }
}
