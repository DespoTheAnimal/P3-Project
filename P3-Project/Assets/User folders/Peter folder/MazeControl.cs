using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeControl : MonoBehaviour
{
    public GameObject uDPReceive;
    private GameObject player;
    List<float> xList = new List<float>();
    List<float> yList = new List<float>();
    public float xPosAdjust = 320;
    public float yPosAdjust = 400;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uDPReceive = GameObject.FindGameObjectWithTag("Server");
    }

    private void FixedUpdate()
    {
        string data = uDPReceive.GetComponent<UDPReceive>().data;
        //The two below lines are removing the brackets in the first and last place
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);

        string[] points = data.Split(',');

        float x = (xPosAdjust - float.Parse(points[0])) / 100;
        float y = (yPosAdjust - float.Parse(points[1])) / 100;
        xList.Add(x);
        yList.Add(y);

        if (xList.Count > 10) { xList.RemoveAt(0); }
        if (yList.Count > 10) { yList.RemoveAt(0); }

        float xAverage = Queryable.Average(xList.AsQueryable());
        float yAverage = Queryable.Average(yList.AsQueryable());

        //En god omgang spaghetti carbonarra...
        if (xAverage > 1.75f)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.right * 2f, ForceMode.Acceleration);
        }
        if (xAverage < -1.75f)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.left * 2f, ForceMode.Acceleration);
        }
        if (yAverage > 1.75f)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * 2f, ForceMode.Acceleration);
        }
        if (yAverage < -1.75f)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.down * 2f, ForceMode.Acceleration);
        }

        /*
        Vector3 playerPos = player.transform.localPosition;

        xAverage = Mathf.Clamp(xAverage, -20f, 20f);
        yAverage = Mathf.Clamp(yAverage, -20f, 20f);
        player.transform.localPosition = new Vector3(xAverage, yAverage, playerPos.z);*/

    }



}
