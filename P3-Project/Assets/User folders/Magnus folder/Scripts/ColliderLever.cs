using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class ColliderLever : MonoBehaviour
{
    public bool lever1;
    public bool lever2;
    public bool lever3;
    public bool doorOpen;

    public static bool enableClick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ILikeToClickItClickIt();
    }

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

    void ILikeToClickItClickIt()
    {
        if (enableClick && Input.GetMouseButtonDown(0))
        {
            lever1 = true;
            Debug.Log(lever1);
        }
    }
}

