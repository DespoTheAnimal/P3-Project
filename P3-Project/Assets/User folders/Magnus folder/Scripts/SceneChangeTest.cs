using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (EndlessCreator.indexOfScene)
            {
                case 1:
                    SceneManager.LoadScene(5);
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
            }

        }
    }
}
