using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleText : MonoBehaviour
{
    [SerializeField] private GameObject textOneHead;
    [SerializeField] private GameObject textOneKeyboard;
    private bool tutorialFollowed = false;
    [SerializeField] private GameObject cube;


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
        if (Input.GetKeyDown(KeyCode.Mouse0) || cube.transform.position.x > -3f || cube.transform.position.x < 3f)
        {
            textOneHead.SetActive(false);
            textOneKeyboard.SetActive(false);
        }
    }
}
