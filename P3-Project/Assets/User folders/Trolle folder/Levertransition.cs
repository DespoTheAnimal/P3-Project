using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levertransition : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Changetransition());
    }

    IEnumerator Changetransition()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("LeverPuzzle");

    }
}
