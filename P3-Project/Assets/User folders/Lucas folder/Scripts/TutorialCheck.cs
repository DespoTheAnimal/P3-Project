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
    private GameObject moveImage;
    [SerializeField]
    private GameObject infoText1;

    private bool canAdd = true;

    private int tutorialPoints = 0;
 
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
            moveImage.SetActive(false);
        } 
    }

    void TextController()
    {
        if (playerObject.transform.position.x <= imageLeftPosition || playerObject.transform.position.x >= imageRightPosition)
        {
            infoText1.SetActive(false);
        }
    }
}
