using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class MazeControl : MonoBehaviour
{
    public bool isHeadTracking = false;
    public float moveSpeed = 40;
    public GameObject uDPReceive;
    private GameObject player;
    public Rigidbody Player;
    List<float> xList = new List<float>();
    List<float> yList = new List<float>();
    public float xPosAdjust = 320;
    public float yPosAdjust = 400;
    public AudioClip clip;
    public AudioSource audioSource;
    public float velocity;

    [SerializeField] private GameObject winText;
    private bool isWinPossible;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uDPReceive = GameObject.FindGameObjectWithTag("Server");
    }

    private void Update()
    {
        if (isWinPossible && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }

        if (Player.velocity.magnitude >= 0.1 && audioSource.isPlaying == false)
        {
            audioSource.PlayOneShot(clip);
            Debug.Log("sound");
        }
        else
        {

        }
    }
    private void FixedUpdate()
    {
        if (isHeadTracking == false)
        {
            MoveControlKeyboard();
        }
        else
        { MoveControlHead(); }


        /*
        Vector3 playerPos = player.transform.localPosition;

        xAverage = Mathf.Clamp(xAverage, -20f, 20f);
        yAverage = Mathf.Clamp(yAverage, -20f, 20f);
        player.transform.localPosition = new Vector3(xAverage, yAverage, playerPos.z);*/

    }

    private void MoveControlKeyboard()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 deltaMove = new Vector3(hor, ver, 0f) * moveSpeed * Time.deltaTime;
        player.GetComponent<Rigidbody>().AddForce(deltaMove, ForceMode.Acceleration);

        /*if (Input.GetKeyDown(KeyCode.D))
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.right * 20f, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.left * 20f, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * 20f, ForceMode.Acceleration);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.down * 20f, ForceMode.Acceleration);
        }*/
    }

    private void MoveControlHead()
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

        Debug.Log(xAverage);
        Debug.Log(yAverage);

        //En god omgang spaghetti carbonarra...
        if (xAverage > 1.75f)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.right * 2f, ForceMode.Acceleration);
        }
        if (xAverage < -.7f)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.left * 2f, ForceMode.Acceleration);
        }
        if (yAverage > 1.75f)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * 2f, ForceMode.Acceleration);
        }
        if (yAverage < -.6f)
        {
            player.GetComponent<Rigidbody>().AddForce(Vector3.down * 2f, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {  
        winText.SetActive(true);
        isWinPossible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        winText.SetActive(false);
        isWinPossible = false;
    }
}
