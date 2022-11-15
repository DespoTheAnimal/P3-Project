using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

//Made from tutorial: https://www.youtube.com/watch?v=m-CHTkMW_ho&ab_channel=Murtaza%27sWorkshop-RoboticsandAIk
public class HeadTracking : MonoBehaviour
{
    public GameObject uDPReceive;
    private GameObject player;
    List<float> xList = new List<float>();
    List<float> yList = new List<float>();
    public float xPosAdjust = 320;
    public float yPosAdjust = 400;

    private bool isGrounded = false;
    public float distanceToHit = 0.9f;

    private int movementSpeed = 2;
    public static float forwardMovement = 10f;
    public static float currentSpeed = 0f;
    private float minSpeed;
    private float maxSpeed = 50f;
    private float timeForSpeed;
    private int accelerationTime = 60;

    private void Awake()
    {
        if(UDPReceive.getStartRecieving == false)
        {
            gameObject.GetComponent<HeadTracking>().enabled = false;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        uDPReceive = GameObject.FindGameObjectWithTag("Server");   
    }

    private void Start()
    {
        timeForSpeed = 0f;
        minSpeed = currentSpeed;
    }

    private void FixedUpdate()
    {
        Grounded();
        Debug.DrawRay(player.transform.position, Vector3.down, Color.cyan);

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

            if (yAverage > 1.75f && Grounded())
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
            }

            Vector3 playerPos = new Vector3(Mathf.Clamp(xAverage, -4f, 4f), player.transform.position.y, player.transform.position.z);

            //xAverage = Mathf.Clamp(xAverage, -4f, 4f);
            //player.transform.localPosition = new Vector3(xAverage, playerPos.y, playerPos.z);
            //player.transform.localPosition = new Vector3(xAverage, player.transform.localPosition.y, transform.localPosition.z);
            player.GetComponent<Rigidbody>().MovePosition(playerPos + new Vector3(0f, 0f, currentSpeed) * Time.deltaTime);

        Debug.Log(Grounded());

    }

    private void Update()
    {
        IncreaseSpeed();
    }

    private bool Grounded()
    {
        //Ray landingRay = new Ray(player.transform.position, new Vector3(0f,-1f,0f));
        return Physics.Raycast(player.transform.position, Vector3.down, distanceToHit + 0.1f);//LayerMask.GetMask("Ignore Raycast"));
    }

    void IncreaseSpeed()
    {
        currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, timeForSpeed / accelerationTime);
        timeForSpeed += Time.deltaTime;
    }
}
