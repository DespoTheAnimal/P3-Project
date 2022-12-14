using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class PlayerBehaviour : MonoBehaviour
{
    //Gradually increase speed 
    public static float forwardMovement = 10f;
    public static float currentSpeed = 0f;
    private float minSpeed = 0;
    private float maxSpeed = 50f;
    private float timeForSpeed;
    private int accelerationTime = 60;
    GameObject player;

    // Character variables for controls
    private Rigidbody rb;
    private int movementSpeed = 5; // Speed for side-to-side movement 
    private float distanceToGround = 1f; // Raycast distance 
    private float gravityFactor = 10f; // Constant force being applied to the player 
    private int jumpHeight = 12; // The height the player jumps
    private bool isJumping;
    private bool isHit;
    private bool isHearts0;
    private bool isFalling;
    private bool isLanding;
    private bool isGrounded;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if(UDPReceive.getStartRecieving == true) // Happens before anything else, checks if UDP is active, if so then this script will not be active.
        {
            gameObject.GetComponent<PlayerBehaviour>().enabled = false;
        }
    }

    void Start()
    {
        timeForSpeed = 0f; // Starts the timer at zero everytime the script has been started 
        currentSpeed = minSpeed; // Sets the minimum speed to the current, making both zero at the start 
        rb = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        IncreaseSpeed();
        // Jump of the player, need both the spacekey to be pressed, and the Jump method to be true 
        if (Input.GetKeyDown(KeyCode.Space) && Jump())
        {
            Debug.Log("test1");
            rb.AddForce(new Vector3(0, jumpHeight * rb.mass, 0), ForceMode.Impulse);
            animator.SetBool("isGrounded", false);
            isGrounded = false;
            Debug.Log(isGrounded);
            animator.SetBool("isJumping", true);
            isJumping = false;
            Debug.Log(isJumping);
        }
        else if (Jump())
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
            
            animator.SetBool("isGrounded", true);
            Debug.Log(isGrounded);
            isGrounded = true;
        }

        // The method for increasing the forward speed of the player through time 
        
    }

    private void FixedUpdate()
    {
        Movement();
        rb.AddForce(new Vector3(0, -1, 0) * gravityFactor, ForceMode.Acceleration);
    }


    /// <summary>
    /// Moves the player with the input from the keyboard from the player's current position. 
    /// </summary>
    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 pos = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f), transform.position.y, transform.position.z);       
        rb.MovePosition(pos + new Vector3(horizontal * movementSpeed, 0f, currentSpeed) * Time.deltaTime);

    }


/// <summary>
/// Checks if the player is currently grounded via a raycast
/// </summary>
/// <returns>True: if the player is grounded, else: False</returns>
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

    /// <summary>
    /// Increases the speed of the player by setting the current forward speed to be interpolated 
    /// </summary>
    void IncreaseSpeed()
    {
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, timeForSpeed / accelerationTime);
        timeForSpeed += Time.deltaTime;
    }
}
