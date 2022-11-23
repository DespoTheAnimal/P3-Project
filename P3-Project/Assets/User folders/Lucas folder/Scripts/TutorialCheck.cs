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

    private bool canAdd;

    private int tutorialPoints = 0;

    
    void Start()
    {
        
    }

   
    void Update()
    {
        SideChecker();
        MoveImageDisabler();
        Debug.Log(tutorialPoints);
    }




    void SideChecker()
    {
        Debug.Log("Player Position =" + playerObject.transform.position.x);

        // skal lige fikses så tutorialpoints ikke tilføjer for meget hele tiden
        if (playerObject.transform.position.x <= scoreLeftPosition || playerObject.transform.position.x >= scoreRightPositon && canAdd)
        {
            tutorialPoints +=1;
            canAdd = false;
        }
        else
        {
            canAdd = true;
        }
    }



    void MoveImageDisabler()
    {
        if (playerObject.transform.position.x <= imageLeftPosition || playerObject.transform.position.x >= imageRightPosition)
        {
            moveImage.SetActive(false);
        } 
    }
}
