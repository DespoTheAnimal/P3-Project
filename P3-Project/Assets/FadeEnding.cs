using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeEnding : MonoBehaviour
{
    public GameObject Fade;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fade());
    }

    IEnumerator fade()
    {
        yield return new WaitForSeconds(6f);
        Fade.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(10);

    }
}
