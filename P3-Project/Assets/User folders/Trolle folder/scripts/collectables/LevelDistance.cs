using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject distanceDisplay;
    public int DistanceRun;
    public static bool addingDistance = false;
    public float timerForAddingDistance = 0.5f;
    //public IEnumerator co;

    private void Start()
    {
        //co = AddingDistance();
    }
    void Update()
    {
        /*if (pausemenu.GameIsPaused)
        {
            Time.timeScale = 0f;
        }*/

        if (addingDistance == false)
        {
            addingDistance = true;
            //StartCoroutine(co);
        }
    }

 

    public IEnumerator AddingDistance()
    {
        while (addingDistance)
        {
            DistanceRun += 1;
            distanceDisplay.GetComponent<TextMeshProUGUI>().text = "" + DistanceRun;
            
            addingDistance = false;
            yield return new WaitForSeconds(timerForAddingDistance);
            //yield break;
        }
        /*while (!addingDistance)
        {

        }*/
    }
}
