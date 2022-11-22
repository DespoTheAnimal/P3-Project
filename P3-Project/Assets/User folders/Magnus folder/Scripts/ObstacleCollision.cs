using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleCollision : MonoBehaviour
{

    // Audio source for the audio clip
    public AudioSource source;
    public AudioClip clip;
    private GameObject Maincamera;
    private void Start()
    {
        Maincamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 

            GameLogic.lives -= 1;
            source.PlayOneShot(clip);
            Debug.Log(clip);
            // Her der skal være en linje kode med animatoren fra main camera så hver gang man bliver ramt så kommer der en animation
            EndlessCreator.movables.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
