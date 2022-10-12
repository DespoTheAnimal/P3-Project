using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generatelevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 80;
    public bool creatingSection = false;
    public int SectionNumber;
   
    void Update()
    {
      if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }  
    }

    IEnumerator GenerateSection()
    {
        SectionNumber = Random.Range(0, 3);
        Instantiate(section[SectionNumber], new Vector3(0, 0, zPos), Quaternion.Euler(0,- 96.6130f, 0));
        zPos += 80;
        yield return new WaitForSeconds (6);
        creatingSection=false;
    }
}
