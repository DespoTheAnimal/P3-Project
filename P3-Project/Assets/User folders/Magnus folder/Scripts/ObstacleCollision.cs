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

            GameLogic.lives -= 1;
            // Her der skal v�re en linje kode med animatoren fra main camera s� hver gang man bliver ramt s� kommer der en animation
            EndlessCreator.movables.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
