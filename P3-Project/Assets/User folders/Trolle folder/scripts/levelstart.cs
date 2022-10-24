using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelstart : MonoBehaviour
{
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGO;
    public GameObject fadeIn;
    //public AudioSource GofX;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countsequence());
    }

    IEnumerator Countsequence()
    {
        yield return new WaitForSeconds(1);
        countDown3.SetActive(true);
        //GofX.Play();
        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownGO.SetActive(true);
    }
}

