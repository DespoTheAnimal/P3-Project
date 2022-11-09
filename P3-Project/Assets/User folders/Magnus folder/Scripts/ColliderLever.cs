using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class ColliderLever : MonoBehaviour
{

    public static bool enableClick;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            Debug.Log("Hit");
            enableClick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cursor"))
        {
            enableClick = false;
        }
    }
}

