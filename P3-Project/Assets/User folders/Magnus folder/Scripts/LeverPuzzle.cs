using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
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

        Debug.Log(lever1);
        Debug.Log(lever2);
        Debug.Log(lever3);

        if(lever1 && lever2 && lever3)
        {
            doorOpen=true;
        }
    }



    //Vi fucking cool ez plebs 
   void OnTriggerStay(Collider other)
    {
        if (ColliderLever.enableClick && other.gameObject.CompareTag("Lever1"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lever1 == true)
                {
                    lever1 = false;
                }
                else lever1 = true;
            }
                
        }
        else if (ColliderLever.enableClick && other.gameObject.CompareTag("Lever2"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lever2 == true)
                {
                    lever2 = false;
                }
                else lever2 = true;
            }
        }

        else if (ColliderLever.enableClick && other.gameObject.CompareTag("Lever3"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lever3 == true)
                {
                    lever3 = false;
                }
                else lever3 = true;
            }
        }
    }
}
