using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourMagnus : MonoBehaviour
{
    public float distanceToGround = 0.2f;
    public bool jump;
    public Rigidbody rb;
    public float jumpheight = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        Jump();
    }

    void Jump()
    {
        if (jump)
        {
            rb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
            jump = false;
        }
    }

    private bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, distanceToGround))
        {
            Debug.Log("Hallo");
            return true;
        }
        else 
        {
            Debug.Log("Oi");
            return false;
           
        }
        
    }
}
