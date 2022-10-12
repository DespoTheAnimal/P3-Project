using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int pointCount;
    public GameObject PointcountDisplay;
    void Update()
    {
        PointcountDisplay.GetComponent<Text>().text = "" + pointCount;
    }
}
