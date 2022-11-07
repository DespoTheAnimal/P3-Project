using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    public float offset = 3f;

    public bool lever1;
    public bool lever2;
    public bool lever3;
    public bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 cursorPos = Input.mousePosition;
        cursorPos.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(cursorPos);
      
    }

    //Vi fucking cool ez plebs 

   /* void OnTriggerEnter(Collider other)
    {
        if (ColliderLever.enableClick && Input.GetMouseButtonDown(1))
        {
            if (other.gameObject.CompareTag("Lever1"))
            {
                lever1 = true;
                if (lever1 == true)
                {
                    lever1 = false;
                }
                Debug.Log(lever1);
            }


            if (other.gameObject.CompareTag("Lever2"))
            {
                lever2 = true;
                if (lever2 == true)
                {
                    lever2 = false;
                }
                Debug.Log(lever2);
            }

            if (other.gameObject.CompareTag("Lever3"))
            {
                lever3 = true;
                if (lever3 == true)
                {
                    lever3 = false;
                }
                Debug.Log(lever3);
            }
        }
    }*/
}
