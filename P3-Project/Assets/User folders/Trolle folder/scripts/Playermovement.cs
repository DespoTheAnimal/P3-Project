using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingpower = 16;
    private bool isfacingRight = true;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("horizontal");

        if (Input.GetButtonDown("jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpingpower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.x > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip()
    {
        if (isfacingRight && horizontal < 0f || !isfacingRight && horizontal > 0f)
        {
            isfacingRight = !isfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }
}
