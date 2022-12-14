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

    public AudioClip audioClip;
    public AudioSource audioSource;

    private void Start()
    {
        puzzler = GameObject.Find("Cube").GetComponent<LeverPuzzle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            enableClick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enableClick = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KeyBoardTrig();
        }
    }

    private void OnMouseDown()
    {
        if (enableClick && gameObject.tag == "Lever1")
        {
            if (puzzler.lever1 == 0)
            {
                puzzler.lever1 = 1;
                puzzler.leverb1.GetComponent<Animator>().Play("LeverUp");
                new WaitForSeconds(0.7f);
                audioSource.PlayOneShot(audioClip);
            }
            else puzzler.lever1 = 0;
            puzzler.leverb1.GetComponent<Animator>().Play("Idle");
            new WaitForSeconds(0.7f);
            audioSource.PlayOneShot(audioClip);
        }
        else if (enableClick && gameObject.tag == "Lever2")
        {
            if (puzzler.lever2 == 0)
            {
                puzzler.lever2 = 1;
                puzzler.leverb2.GetComponent<Animator>().Play("LeverUp");
                new WaitForSeconds(0.7f);
                audioSource.PlayOneShot(audioClip);
            }
            else puzzler.lever2 = 0;
            puzzler.leverb2.GetComponent<Animator>().Play("Idle");
            new WaitForSeconds(0.7f);
            audioSource.PlayOneShot(audioClip);
        }
        else if (enableClick && gameObject.tag == "Lever3")
        {
            if (puzzler.lever3 == 0)
            {
                puzzler.lever3 = 1;
                puzzler.leverb3.GetComponent<Animator>().Play("LeverUp");
                new WaitForSeconds(0.7f);
                audioSource.PlayOneShot(audioClip);
            }
            else puzzler.lever3 = 0;
            puzzler.leverb3.GetComponent<Animator>().Play("Idle");
            new WaitForSeconds(0.7f);
            audioSource.PlayOneShot(audioClip);
        }
    }

    private void KeyBoardTrig()
    {
        if (enableClick && gameObject.tag == "Lever1")
        {
            if (puzzler.lever1 == 0)
            {
                puzzler.lever1 = 1;
                puzzler.leverb1.GetComponent<Animator>().Play("LeverUp");
                new WaitForSeconds(0.7f);
                audioSource.PlayOneShot(audioClip);
            }
            else puzzler.lever1 = 0;
            puzzler.leverb1.GetComponent<Animator>().Play("Idle");
            new WaitForSeconds(0.7f);
            audioSource.PlayOneShot(audioClip);
        }
        else if (enableClick && gameObject.tag == "Lever2")
        {
            if (puzzler.lever2 == 0)
            {
                puzzler.lever2 = 1;
                puzzler.leverb2.GetComponent<Animator>().Play("LeverUp");
                new WaitForSeconds(0.7f);
                audioSource.PlayOneShot(audioClip);
            }
            else puzzler.lever2 = 0;
            puzzler.leverb2.GetComponent<Animator>().Play("Idle");
            new WaitForSeconds(0.7f);
            audioSource.PlayOneShot(audioClip);
        }
        else if (enableClick && gameObject.tag == "Lever3")
        {
            if (puzzler.lever3 == 0)
            {
                puzzler.lever3 = 1;
                puzzler.leverb3.GetComponent<Animator>().Play("LeverUp");
                new WaitForSeconds(0.7f);
                audioSource.PlayOneShot(audioClip);
            }
            else puzzler.lever3 = 0;
            puzzler.leverb3.GetComponent<Animator>().Play("Idle");
            new WaitForSeconds(0.7f);
            audioSource.PlayOneShot(audioClip);
        }
    }
}
