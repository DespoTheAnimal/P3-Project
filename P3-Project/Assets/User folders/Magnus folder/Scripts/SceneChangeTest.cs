using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class SceneChangeTest : MonoBehaviour
{
    EndlessSpawner _ES;
    List<int> SceneIndex = new List<int>{3,4,5};
    private int rand;
    private int numberPicked;

    private void Start()
    {
        _ES = GameObject.Find("GameManager").GetComponent<EndlessSpawner>();
        RandomScene();
        Debug.Log(numberPicked);
        Debug.Log(SceneIndex.Count);

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
        rand = Random.Range(0, 2);
        //int randomInt = SceneIndex[rand];
        //numberPicked = SceneIndex[randomInt];
        numberPicked = SceneIndex[rand];
        //SceneIndex.Remove(numberPicked);
        SceneManager.LoadScene(numberPicked);
    }
}
