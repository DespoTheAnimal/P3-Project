using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class ColliderLever : MonoBehaviour
{
    LeverPuzzle puzzler;

    public bool enableClick;

    AudioClip audioClip;
    AudioSource audioSource;

    private void Start()
    {
        puzzler = GameObject.Find("Cube").GetComponent<LeverPuzzle>();
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

    private void OnMouseDown()
    {
        if (enableClick && gameObject.tag == "Lever1")
        {
            if (puzzler.lever1 == 0)
            {
                puzzler.lever1 = 1;
                //audioSource.PlayOneShot(audioClip);
                puzzler.leverb1.GetComponent<Animator>().Play("LeverUp");
            }
            else puzzler.lever1 = 0;
            puzzler.leverb1.GetComponent<Animator>().Play("Idle");
        }
        else if (enableClick && gameObject.tag == "Lever2")
        {
            if (puzzler.lever2 == 0)
            {
                puzzler.lever2 = 1;
                //audioSource.PlayOneShot(audioClip);
                puzzler.leverb2.GetComponent<Animator>().Play("LeverUp");
            }
            else puzzler.lever2 = 0;
            puzzler.leverb2.GetComponent<Animator>().Play("Idle");
        }
        else if (enableClick && gameObject.tag == "Lever3")
        {
            if (puzzler.lever3 == 0)
            {
                puzzler.lever3 = 1;
                //audioSource.PlayOneShot(audioClip);
                puzzler.leverb3.GetComponent<Animator>().Play("LeverUp");
            }
            else puzzler.lever3 = 0;
            puzzler.leverb3.GetComponent<Animator>().Play("Idle");
        }
    }
}

