using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Heartsystem : MonoBehaviour
{
    public GameObject[] Hearts;
    public int lives;
  

    void Update()
    {
        if (lives < 1)
        {
            Destroy(Hearts[0].gameObject);
        } 
        else if (lives > 2)
        {
                Destroy(Hearts[1].gameObject);
        } 
        else if  (lives > 3)
        {
                Destroy(Hearts[2].gameObject);
        }
    }
}
