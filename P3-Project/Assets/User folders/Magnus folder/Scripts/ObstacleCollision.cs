using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleCollision : MonoBehaviour
{
    private GameObject Maincamera;
    private void Start()
    {
        Maincamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Maincamera.GetComponent<Animator>().enabled = true;

            PlayerBehaviourMagnus.lives -= 1;
            // Her der skal være en linje kode med animatoren fra main camera så hver gang man bliver ramt så kommer der en animation
            EndlessCreator.movables.Remove(gameObject);
            Destroy(gameObject);
            // Maincamera.GetComponent<Animator>().enabled = false;
            
        }
    }
}
