using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RotatePuzzle : MonoBehaviour
{
    public GameObject uDPReceive;
    private GameObject player;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject win;
    List<float> xList = new List<float>();
    public float xPosAdjust = 320;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uDPReceive = GameObject.FindGameObjectWithTag("Server");
    }

    private void FixedUpdate()
    {
        Rotation();
    }


    private void Rotation()
    {
        string data = uDPReceive.GetComponent<UDPReceive>().data;
        //The two below lines are removing the brackets in the first and last place
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);

        string[] points = data.Split(',');

        float x = (float.Parse(points[0]) - xPosAdjust) / 100;
        xList.Add(x);

        if (xList.Count > 10) { xList.RemoveAt(0); }

        float zAverage = Queryable.Average(xList.AsQueryable());

        Vector3 playerPos = player.transform.localPosition;

        player.transform.Rotate(player.transform.rotation.x, player.transform.rotation.y, zAverage, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        win.SetActive(true);
    }
}
