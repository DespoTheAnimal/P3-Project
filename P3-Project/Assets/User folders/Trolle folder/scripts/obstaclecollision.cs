using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclecollision : MonoBehaviour
{
    public GameObject thePlayer;
    public AudioSource gameOver;
    public GameObject MainCamera;
    public GameObject fadeOut;
    public GameObject Respawn;

   
    IEnumerator Countsequence()
    {
        yield return new WaitForSeconds(0.1f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        Respawn.SetActive(true);
    }


        private void OnTriggerEnter(Collider other)
    {
       this.gameObject.GetComponent<BoxCollider>().enabled = false;
       thePlayer.GetComponent<PlayerMove>().enabled = false;
       // gameOver.Play();
       // StartCoroutine(Countsequence());
        //blood.GetComponent<emission>().enabled = true;
        MainCamera.GetComponent<Animator>().enabled = true;
    }
}
