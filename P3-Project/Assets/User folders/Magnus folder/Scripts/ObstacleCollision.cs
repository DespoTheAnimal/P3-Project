using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleCollision : MonoBehaviour
{
    public GameObject Maincamera;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Maincamera.GetComponent<Animator>().enabled = true;
            PlayerBehaviourMagnus.lives -= 1;
            // Her der skal v�re en linje kode med animatoren fra main camera s� hver gang man bliver ramt s� kommer der en animation
            EndlessCreator.movables.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
