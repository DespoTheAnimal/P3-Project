using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheck : MonoBehaviour
{
    private float leftPosition;
    private float rightPositon;

    [SerializeField]
    private GameObject playerObject;

    
    void Start()
    {
        
    }

   
    void Update()
    {
        Debug.Log("Player Positio =" + playerObject.transform.position.x);
    }
}
