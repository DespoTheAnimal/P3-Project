using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood : MonoBehaviour
{
    public AudioSource FoodFX;

    private void OnTriggerEnter(Collider other)
    {
        FoodFX.Play();
        CollectableControl.pointCount += 75;
        this.gameObject.SetActive(false);
    }
}
