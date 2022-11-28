using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionMaze : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fade());
    }

    IEnumerator fade()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("MazePuzzle");

    }
}
