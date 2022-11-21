using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteGround : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;



    }

    private void Update()
    {
        transform.position = new Vector3(0f,0f, player.position.z - 51f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ILikeToMoveItMoveIt") || other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Obstacles"))
        {
            Destroy(other.gameObject);
            //EndlessCreator.movables.Remove(other.gameObject);
        }
    }
}
