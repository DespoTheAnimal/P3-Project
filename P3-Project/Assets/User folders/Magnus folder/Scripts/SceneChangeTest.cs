using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeTest : MonoBehaviour
{
    EndlessSpawner _ES;
    List<int> SceneIndex = new List<int>();
    private int rand;

    private void Start()
    {
        _ES = GameObject.Find("GameManager").GetComponent<EndlessSpawner>();
        SceneIndex.Add(3);
        SceneIndex.Add(4);
        SceneIndex.Add(5);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SwitchSceneEz();
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
        rand = Random.Range(0, SceneIndex.Count);
        SceneIndex.Remove(rand);
        SceneManager.LoadScene(rand);
    }
}
