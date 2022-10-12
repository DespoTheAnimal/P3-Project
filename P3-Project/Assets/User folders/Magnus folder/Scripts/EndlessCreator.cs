using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessCreator : MonoBehaviour
{
    public GameObject ground;
    [SerializeField]
    private int planeStartPoint = 50;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(PlaneGeneration());
    }

    IEnumerator PlaneGeneration()
    {
        yield return new WaitForSeconds(2);
        //Instantiate(ground, new Vector3(transform.position.x, transform.position.y, transform.position.z + planeStartPoint), Quaternion.identity);
        for (int i = 0; i <= MagicNumberScript1.movables.Count; i++)
        {
            MagicNumberScript1.movables[i].transform.Translate(Vector3.back * MagicNumberScript1.speed * Time.deltaTime);
            i++;
        }
        MagicNumberScript1.movables.Add(ground);
        planeStartPoint += 50;
        yield break;
       
    }
}
