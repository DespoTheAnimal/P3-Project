using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float leftSide = -7f;
    public static float rightSide = 7f;
    public float internalRight;
    public float internalLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        internalRight = rightSide;
        internalLeft = leftSide;
    }
}
