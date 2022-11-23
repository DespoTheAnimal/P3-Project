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

    private bool canAdd;

    private int tutorialPoints = 0;

    
    void Start()
    {
        
    }

   
    void Update()
    {
        SideChecker();
        ImageController();
        TextController();
        Debug.Log("lol points" + tutorialPoints);
    }

    void SideChecker()
    {
        // skal lige fikses så tutorialpoints ikke tilføjer for meget hele tiden
        if (canAdd && playerObject.transform.position.x <= scoreLeftPosition || canAdd && playerObject.transform.position.x >= scoreRightPositon)
        {
            tutorialPoints++;
            canAdd = false;
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
