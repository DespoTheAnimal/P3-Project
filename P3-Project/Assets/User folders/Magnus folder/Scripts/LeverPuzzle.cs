using UnityEngine;
using Input = UnityEngine.Input;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class LeverPuzzle : MonoBehaviour
{
    public GameObject uDPReceive;
    private GameObject player;
    List<float> xList = new List<float>();
    List<float> yList = new List<float>();
    public float xPosAdjust = 320;
    public float yPosAdjust = 400;
    public float offset = 3f;
    public bool isHeadTrack = true;

    public int lever1;
    public int lever2;
    public int lever3;
    public int leverCheck1;
    public int leverCheck2;
    public int leverCheck3;
    public bool doorOpen;

    public bool lever1Active;
    public bool lever2Active;
    public bool lever3Active;

    [SerializeField] public GameObject leverb1;
    [SerializeField] public GameObject leverb2;
    [SerializeField] public GameObject leverb3;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uDPReceive = GameObject.FindGameObjectWithTag("Server");
    }

    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        lever1 = Random.Range(0, 2);
        lever2 = Random.Range(0, 2);
        lever3 = Random.Range(0, 2);

        leverCheck1 = Random.Range(0, 2);
        leverCheck2 = Random.Range(0, 2);
        leverCheck3 = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeadTrack == true)
        {
            HeadControl();
        }
        else
        {
            MouseControl();
        }

        if(lever1 == leverCheck1 &&  lever2 == leverCheck2 && lever3 == leverCheck3)
        {
            doorOpen=true;
            SceneManager.LoadScene(1);
        }


        Debug.Log(lever1);
        Debug.Log(lever2);
        Debug.Log(lever3);

        Debug.Log(leverCheck1);
        Debug.Log(leverCheck2);
        Debug.Log(leverCheck3);

    }

    private void MouseControl()
    {
        Vector3 cursorPos = Input.mousePosition;
        cursorPos.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(cursorPos);
    }
    private void HeadControl()
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
        Vector3 playerPos = new Vector3(Mathf.Clamp(xAverage, -4f, 4f), player.transform.position.y, player.transform.position.z);

        //player.transform.localPosition = new Vector3(xAverage, playerPos.y, playerPos.z);
        player.transform.localPosition = new Vector3(xAverage, yAverage, 15.95f);
    }
}
