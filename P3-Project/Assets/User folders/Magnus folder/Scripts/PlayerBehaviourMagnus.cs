using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            Jump();
        }
    }

    void Jump()
    {
       
         rb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
         jump = false;
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(GameObject.FindGameObjectWithTag("ILikeToMoveItMoveIt"))
        {
            jump = true;
            Debug.Log("Jump is possible");
        }
        else
        {
            jump = false;
            Debug.Log("Jump is not possible");
        }
    }

};
