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

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            item = GameObject.Find("Player");
        }

        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            item = GameObject.Find("Cube");
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 7)
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
        if(SceneManager.GetActiveScene().buildIndex == 9)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || item.transform.rotation.z > 20 || item.transform.rotation.z < -20)
            {
                textOneHead.SetActive(false);
                textOneKeyboard.SetActive(false);
            }
        }
        //Lever puzzle scene
        if(SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || item.transform.position.x > -3f || item.transform.position.x < 3f)
            {
                textOneHead.SetActive(false);
                textOneKeyboard.SetActive(false);
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (item.transform.position.x > -9 || item.transform.position.x < -15 || item.transform.position.y < 0.75f || item.transform.position.y > 6f)
            {
                textOneHead.SetActive(false);
                textOneKeyboard.SetActive(false);
            }
        }
    }
}
