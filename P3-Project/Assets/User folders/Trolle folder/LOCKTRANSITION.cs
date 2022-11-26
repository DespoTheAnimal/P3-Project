using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOCKTRANSITION : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangEtransition());
    }

    IEnumerator ChangEtransition()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("RotatingPuzzle");

    }
}
