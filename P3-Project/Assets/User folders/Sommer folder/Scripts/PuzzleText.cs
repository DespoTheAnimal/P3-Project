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

    private float timerLever = 7;
    private float timerRotating = 7;
    private float timerMaze = 7;
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
            timerRotating = timerRotating - Time.deltaTime;
            if (timerRotating <= 0.5f)
            {
                textOneHead.SetActive(false);
                textOneKeyboard.SetActive(false);
            }
        }
        //Lever puzzle scene
        if(SceneManager.GetActiveScene().buildIndex == 9)
        {
            timerLever = timerLever - Time.deltaTime;
            if (timerLever <= 0.5f)
            {
                textOneHead.SetActive(false);
                textOneKeyboard.SetActive(false);
            }
        }
        //Maze puzzle scene
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            timerMaze = timerMaze - Time.deltaTime;
            if (timerMaze <= 0.5f)
            {
                textOneHead.SetActive(false);
                textOneKeyboard.SetActive(false);
            }
        }
    }
}
