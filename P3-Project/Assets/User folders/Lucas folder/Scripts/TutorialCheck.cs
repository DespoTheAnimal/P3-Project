using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameObject pointText1;
    [SerializeField]
    private TextMeshProUGUI actualPointText;

    private bool canAdd = true;
    private bool canJump = true;
    private bool headControl;

    private bool firstStageComplete = false;

    private int tutorialPoints = 0;

    private void Start()
    {
        pointText1.SetActive(false);
        jumpHeadText1.SetActive(false);
        jumpHeadImage.SetActive(false);
        keyboardJumpImage.SetActive(false);
        keyboardJumpText1.SetActive(false);
        actualPointText.gameObject.SetActive(false);

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
        AddPointsText();
        SideChecker();
        ImageController();
        TextController();
        PointsChecker();

        if (firstStageComplete)
        {
            JumpChecker();
        }
        if (tutorialPoints >= 4 && firstStageComplete)
        {
            //Tutorial is over, we can display text or changescene.
            SceneManager.LoadScene("TheActualGame");
        }
    }

    void SideChecker()
    {
        if (canAdd && playerObject.transform.position.x <= scoreLeftPosition && !firstStageComplete|| canAdd && playerObject.transform.position.x >= scoreRightPositon && !firstStageComplete)
        {
            tutorialPoints++;
            actualPointText.gameObject.SetActive(true);
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
                if (!firstStageComplete)
                {
                    pointText1.SetActive(true);
                }

            }
        }
        else
        {
            if (playerObject.transform.position.x <= imageLeftPosition || playerObject.transform.position.x >= imageRightPosition)
            {
                moveKeyboardText1.SetActive(false);
                if (!firstStageComplete)
                {
                    pointText1.SetActive(true);
                }
            }
        }
    }

    void JumpChecker()
    {
        if(canJump && playerObject.transform.position.y > 3 && firstStageComplete)
        {
            canJump = false;
            tutorialPoints++;
        }
        else if(!canJump && playerObject.transform.position.y < 3 && firstStageComplete)
        {
            canJump = true;
        }

    }

    void PointsChecker()
    {
        if (tutorialPoints == 4 && UDPReceive.getStartRecieving == true)
        {
            pointText1.SetActive(false);
            jumpHeadImage.SetActive(true);
            jumpHeadText1.SetActive(true);

            tutorialPoints = 0;
            firstStageComplete = true;
        }
        else if (tutorialPoints == 4 && UDPReceive.getStartRecieving == false)
        {
            pointText1.SetActive(false);
            keyboardJumpImage.SetActive(true);
            keyboardJumpText1.SetActive(true);
            tutorialPoints = 0;
            firstStageComplete = true;
        }
    }

    void AddPointsText()
    {
        actualPointText.text = tutorialPoints+" out of 4";
    }
}
