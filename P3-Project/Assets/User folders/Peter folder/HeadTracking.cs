using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Made from tutorial: https://www.youtube.com/watch?v=m-CHTkMW_ho&ab_channel=Murtaza%27sWorkshop-RoboticsandAIk
public class HeadTracking : MonoBehaviour
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

    private void Update()
    {
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

            Vector3 playerPos = player.transform.localPosition;

            player.transform.localPosition = new Vector3(xAverage, yAverage, playerPos.z);

        }
    }
}
