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
    private GameObject jumpHeadText1;

    [SerializeField]
    private GameObject keyboardMoveImage;
    [SerializeField]
    private GameObject keyboardJumpImage;
    [SerializeField]
    private GameObject moveKeyboardText1;
    [SerializeField]
    private GameObject keyboardJumpText1;

    private bool canAdd = true;
    private bool headControl;

    private int tutorialPoints = 0;

    private void Start()
    {
        jumpHeadText1.SetActive(false);
        jumpHeadImage.SetActive(false);
        keyboardJumpImage.SetActive(false);
        keyboardJumpText1.SetActive(false);

        if (UDPReceive.getStartRecieving == true)
        {
            headControl = true;
            moveHeadImage.SetActive(true);
            moveBodyText1.SetActive(true);

            keyboardMoveImage.SetActive(false);
            moveKeyboardText1.SetActive(false);
        }
        else
        {
            keyboardMoveImage.SetActive(true);
            moveKeyboardText1.SetActive(true);

            moveHeadImage.SetActive(false);
            moveBodyText1.SetActive(false);
        }
    }

    void Update()
    {
        SideChecker();
        ImageController();
        TextController();
        PointsChecker();
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
        if (headControl == true)
        {
            if (playerObject.transform.position.x <= imageLeftPosition || playerObject.transform.position.x >= imageRightPosition)
            {
                moveHeadImage.SetActive(false);
            }
        }
        else
        {
            if (playerObject.transform.position.x <= imageLeftPosition || playerObject.transform.position.x >= imageRightPosition)
            {
                keyboardMoveImage.SetActive(false);
            }
        }
        
    }

    void TextController()
    {
        if (headControl == true)
        {
            if (playerObject.transform.position.x <= imageLeftPosition || playerObject.transform.position.x >= imageRightPosition)
            {
                moveBodyText1.SetActive(false);
            }
        }
        else
        {
            if (playerObject.transform.position.x <= imageLeftPosition || playerObject.transform.position.x >= imageRightPosition)
            {
                moveKeyboardText1.SetActive(false);
            }
        }
    }

    void PointsChecker()
    {
        if (tutorialPoints == 4 && UDPReceive.getStartRecieving == true)
        {
            jumpHeadImage.SetActive(true);
            jumpHeadText1.SetActive(true);
        }
        else if (tutorialPoints == 4 && UDPReceive.getStartRecieving == false)
        {
            keyboardJumpImage.SetActive(true);
            keyboardJumpText1.SetActive(true);
        }
    }
}
