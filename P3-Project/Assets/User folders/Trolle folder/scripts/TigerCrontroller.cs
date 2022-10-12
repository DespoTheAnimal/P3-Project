using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerCrontroller : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    private CharacterController characterController;
    private float ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalinput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButtonDown("jump"))
        {
            ySpeed = jumpSpeed;
        }

        characterController.SimpleMove(movementDirection*magnitude);
       // if (movementDirection != Vector3.zero)
        //{
            //Quaternion toRotiation = Quaternion.LookRotation(movementDirection,Vector3.up);
          //  transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotiation, rotationSpeed * Time.deltaTime);
        //}
    }
}
