using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingwithsoundakaboogiewoogie : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public float thresholdChange = 0.5f;
    private Vector3 lastTransformPos;
    private void Start()
    {
        lastTransformPos = transform.position;
    }


    private void update ()
    {
        var diffVector = transform.position - lastTransformPos;
        if (diffVector.magnitude >= thresholdChange)
        {
            lastTransformPos = transform.position;
            audioSource.PlayOneShot(audioClip);
            //Do something 
        }
    }

}
