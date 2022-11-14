using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Gradually increase speed
    public static float forwardMovement = 10f;
    private float maxSpeed = 500f;
    private float acceleration = 10f;
    private float deceleration = 10f;


    private Rigidbody rb;
    private static int movementSpeed = 5;
    private float distanceToGround = 1f;
    private float gravityFactor = 10f;

    Vector3 cameraMoveMaybe;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Camera.main.transform.position = cameraMoveMaybe;
        //cameraMoveMaybe = new Vector3(0f, 5f, transform.position.z - 10f);
        //Camera.main.transform.rotation = Quaternion.identity;

        if (Input.GetKeyDown(KeyCode.Space) && Jump())
        {
            rb.AddForce(new Vector3(0, 10 * rb.mass, 0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Movement();
        rb.AddForce(new Vector3(0, -1, 0) * gravityFactor, ForceMode.Acceleration);
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.MovePosition(transform.position + new Vector3(horizontal * movementSpeed, 0f, forwardMovement) * Time.deltaTime);

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
}
