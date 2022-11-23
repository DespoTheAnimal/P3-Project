using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class SceneChangeTest : MonoBehaviour
{
    EndlessSpawner _ES;
    GameObject uDP;
    List<int> PuzzlesLeft;
    private int rand;
    private int numberPicked;

    private void Start()
    {
        _ES = GameObject.Find("GameManager").GetComponent<EndlessSpawner>();
        uDP = GameObject.FindGameObjectWithTag("Server");
        PuzzlesLeft = uDP.GetComponent<UDPReceive>().PuzzleIndex;
        Debug.Log(PuzzlesLeft.Count);
        //RandomScene();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //SwitchSceneEz();
            RandomScene();
        }
    }

    void SwitchSceneEz()
    {
        switch (_ES.indexOfScene)
        {
            case 1:
                SceneManager.LoadScene(5);
                _ES.indexOfScene += 1;
                break;
            default:
                Debug.Log("Didn't Work");
                break;
        }
    }

    private void RandomScene()
    {
        if (PuzzlesLeft.Count != 0)
        {
            rand = Random.Range(0, PuzzlesLeft.Count);
            //int randomInt = SceneIndex[rand];
            //numberPicked = SceneIndex[randomInt];
            numberPicked = PuzzlesLeft[rand];
            uDP.GetComponent<UDPReceive>().PuzzleIndex.Remove(numberPicked);
            SceneManager.LoadScene(numberPicked);
        }
        else
        {
            SceneManager.LoadScene("winning scene");
        }
    }
}
