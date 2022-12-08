using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PuzzleText : MonoBehaviour
{
    [SerializeField] private GameObject textOneHead;
    [SerializeField] private GameObject textOneKeyboard;
    private bool tutorialFollowed = false;
    [SerializeField] private GameObject item;

    private float timer = 7;
    private void Awake()
    {
        //Rotating puzzle
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            item = GameObject.Find("Player");
        }
        //Lever puzzle
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            item = GameObject.Find("Cube");
        }
        //Maze puzzle
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            item = GameObject.Find("Player");
        }
    }
    void Start()
    {
        if (UDPReceive.getStartRecieving == true && !tutorialFollowed)
        {
            textOneKeyboard.SetActive(false);
            textOneHead.SetActive(true);
        }
        else
        {
            textOneHead.SetActive(false);
            textOneKeyboard.SetActive(true);
        }
    }
    void Update()
    {
        //Rotating puzzle scene
        if(SceneManager.GetActiveScene().buildIndex == 10)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || item.transform.rotation.z > 20 || item.transform.rotation.z < -20)
            {
                textOneHead.SetActive(false);
                textOneKeyboard.SetActive(false);
            }
        }
        //Lever puzzle scene
        if(SceneManager.GetActiveScene().buildIndex == 9)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0.5f)
            {
                textOneHead.SetActive(false);
                textOneKeyboard.SetActive(false);
            }
        }
        //Maze puzzle scene
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (item.transform.position.x > -9 || item.transform.position.x < -15 || item.transform.position.y < 0.75f || item.transform.position.y > 6f)
            {
                textOneHead.SetActive(false);
                textOneKeyboard.SetActive(false);
            }
        }
    }
}
