using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerBehaviourMagnus.lives -= 1;
            EndlessCreator.movables.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
