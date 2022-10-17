using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class PlayerBehaviourMagnus : MonoBehaviour
{
    public float distanceToGround = 0.2f;
    public bool jump;
    public Rigidbody rb;
    public float jumpheight = 5f;
    public int speed = 2;

    public static int lives = 3;
    private int score;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump)
        {
            Jump();
        }
        MovementKeyboard();
        Debug.Log(lives);
        LoseCondition();
        ScoreSystem();
    }

    void Jump()
    {
       
         rb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
         jump = false;
       
    }

    void MovementKeyboard()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed *Time.deltaTime;
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(horizontal + pos.x, -4f, 4f);
        transform.position = pos;

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

    void LoseCondition()
    {
        if(lives == 0)
        {
            PlayerPrefs.SetInt("NewScore", score);
            SceneManager.LoadScene("YouDied");
        }
    }

    void ScoreSystem()
    {
        score += 1;
        text.text = score.ToString();
    }
};
