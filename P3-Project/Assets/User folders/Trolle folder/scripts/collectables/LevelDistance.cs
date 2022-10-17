using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject distanceDisplay;
    public int DistanceRun;
    public bool addingDistance = false;
    public float timerForAddingDistance = 0.15f;  


    void Update()
    {
        if (addingDistance == false)
        {
            addingDistance = true;
            StartCoroutine(AddingDistance());
        }
    }

    public IEnumerator AddingDistance()
    {
        DistanceRun += 1;
        distanceDisplay.GetComponent<Text>().text = "" + DistanceRun;
        yield return new WaitForSeconds(timerForAddingDistance);
        addingDistance = false;
    }
}
