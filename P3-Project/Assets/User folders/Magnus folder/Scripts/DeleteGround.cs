using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ILikeToMoveItMoveIt") || other.gameObject.CompareTag("Floor"))
        {
            Destroy(other.gameObject);
            //EndlessCreator.movables.Remove(other.gameObject);
        }
    }
}
