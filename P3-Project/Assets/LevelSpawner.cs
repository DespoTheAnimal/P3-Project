using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    // Reference to the EndlessSpawner Script for spawning the playarea 
    EndlessSpawner spawner;

    private void Start()
    {
        spawner = GameObject.Find("GameManager").GetComponent<EndlessSpawner>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawner.SpawnWall();
        }
    }
}
