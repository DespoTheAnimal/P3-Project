using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(6);
            /*switch (EndlessCreator.indexOfScene)
            {
                case 1:
                    SceneManager.LoadScene(5);
                    break;
                default:
                    Debug.Log("Didn't Work");
                    break;
            }*/
        }
    }
}
