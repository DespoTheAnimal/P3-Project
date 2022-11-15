using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleCollision : MonoBehaviour
{
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
            // Her der skal v�re en linje kode med animatoren fra main camera s� hver gang man bliver ramt s� kommer der en animation
            EndlessCreator.movables.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
