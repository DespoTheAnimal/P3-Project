using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class RotatePuzzle : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip lockSound;

    public GameObject uDPReceive;
    private GameObject player;
    private GameObject key;
    [SerializeField] private GameObject win;
    List<float> xList = new List<float>();
    public float xPosAdjust = 320;

    private bool isWin = false;
    private int locksUnlocked = 0;

    private List<GameObject> KeyList;
    GameObject[] keyArray;
    private GameObject newkey;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uDPReceive = GameObject.FindGameObjectWithTag("Server");
        keyArray = GameObject.FindGameObjectsWithTag("Keys");
        audioSource = GetComponent<AudioSource>();

        keyArray.ToList<GameObject>();
        RandomizeActiveComponent();
    }
    
    private void RandomizeActiveComponent()
    {
        int randomNr = Random.Range(0, keyArray.Length);
        newkey = keyArray[randomNr];
        Debug.Log(newkey);

        foreach (GameObject key in keyArray)
        {
            key.SetActive(false);

            if (newkey == keyArray[randomNr])
            {
                newkey.SetActive(true);
            }
        }  
    }

    private void Update()
    {
        if(UDPReceive.getStartRecieving == true)
        {
            RotationHead();
        }
        else
        {
            RotationKeyboard();
        }

        if (locksUnlocked >= 3)
        {
            audioSource.PlayOneShot(lockSound, 1f);
            SceneManager.LoadScene("TheActualGame");
        }

        if (Input.GetKeyDown(KeyCode.Space) && isWin == true)
        {
            audioSource.PlayOneShot(lockSound, 1f);
            locksUnlocked++;
            RandomizeActiveComponent();
            win.SetActive(false);
        }
    }

    private void RotationHead()
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

    private void RotationKeyboard()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            player.transform.Rotate(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z + 5, Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.transform.Rotate(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z + -5, Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        win.SetActive(true);
        isWin = true;
    }
    private void OnTriggerExit(Collider other)
    {
        win.SetActive(false);
        isWin = false;
    }

}
