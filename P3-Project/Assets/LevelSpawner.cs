using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
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
