using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made from tutorial: https://www.youtube.com/watch?v=m-CHTkMW_ho&ab_channel=Murtaza%27sWorkshop-RoboticsandAI
public class HeadTracking : MonoBehaviour
{
    public UDPReceive uDPReceive;
    public GameObject player;

    private void Update()
    {
        string data = uDPReceive.data;
        //The two below lines are removing the brackets in the first and last place
        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);

        string[] points = data.Split(',');

        float x = float.Parse(points[0]) / 100;
        float y = float.Parse(points[1]) / 100;

        Vector3 playerPos = player.transform.localPosition;

        player.transform.localPosition = new Vector3(x, playerPos.y, playerPos.z);

    }
}
