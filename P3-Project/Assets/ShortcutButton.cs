using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShortcutButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Maze Transition
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(4);
        }
        // Lock Transition
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(5);
        }
        // Lever Transition
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(6);
        }
    }
}
