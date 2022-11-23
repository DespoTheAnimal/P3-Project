using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheck : MonoBehaviour
{
    private float scoreLeftPosition = -7.5f;
    private float scoreRightPositon = 7.5f;

    private float imageLeftPosition = -2.5f;
    private float imageRightPosition = 2.5f;

    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private GameObject moveHeadImage;
    [SerializeField]
    private GameObject jumpHeadImage;
    [SerializeField]
    private GameObject moveBodyText1;

    [SerializeField]
    private GameObject keyboardMoveImage;
    //[SerializeField]
    //private GameObject keyboardJumpImage;
    [SerializeField]
    private GameObject moveKeyboardText1;

    private bool canAdd = true;

    private int tutorialPoints = 0;

    private void Start()
    {
        if (UDPReceive.getStartRecieving == true)
        {
            moveHeadImage.SetActive(true);
            moveBodyText1.SetActive(true);

            jumpHeadImage.SetActive(false);
            //keyboardJumpImage.SetActive(false);
            keyboardMoveImage.SetActive(false);
            moveKeyboardText1.SetActive(false);
        }
        else
        {
            keyboardMoveImage.SetActive(true);
            moveKeyboardText1.SetActive(true);

            moveHeadImage.SetActive(false);
            moveBodyText1.SetActive(false);
            jumpHeadImage?.SetActive(false);
            //keyboardJumpImage.SetActive(false);
        }
    }

    void Update()
    {
        SideChecker();
        ImageController();
        TextController();
        Debug.Log("lol points" + tutorialPoints);
        Debug.Log(canAdd);
    }

    void SideChecker()
    {
        if (canAdd && playerObject.transform.position.x <= scoreLeftPosition || canAdd && playerObject.transform.position.x >= scoreRightPositon)
        {
            Debug.Log("hey sexy");
            tutorialPoints++;
            canAdd = false;
        }
        else if (!canAdd && playerObject.transform.position.x > scoreLeftPosition && playerObject.transform.position.x < scoreRightPositon)
        {
            canAdd = true;
        }
    }

    void ImageController()
    {
        if (playerObject.transform.position.x <= imageLeftPosition || playerObject.transform.position.x >= imageRightPosition)
        {
            moveHeadImage.SetActive(false);
        } 
    }

    void TextController()
    {
        if (playerObject.transform.position.x <= imageLeftPosition || playerObject.transform.position.x >= imageRightPosition)
        {
            moveBodyText1.SetActive(false);
        }
    }
}
