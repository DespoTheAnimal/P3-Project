using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeTest : MonoBehaviour
{
    EndlessSpawner _ES;

    private void Start()
    {
        _ES = GameObject.Find("GameManager").GetComponent<EndlessSpawner>();
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
}
