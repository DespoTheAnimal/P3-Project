using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    ParticleSystem particle;
    // Audio source for the audio clip
    public AudioClip clip;
    private GameObject Maincamera;
    private AudioSource audios;
    Animator animator;
    private bool isHit;
    private void Start()
    {
        animator = GetComponent<Animator>();
        particle = GameObject.Find("Player").GetComponentInChildren<ParticleSystem>();
        Maincamera = GameObject.FindGameObjectWithTag("MainCamera");
        audios = GameObject.Find("Player").GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            GameLogic.lives -= 1;
            particle.Play();
            animator.SetBool("isHit", true);
            isHit = true;
            audios.PlayOneShot(clip);
            Debug.Log(clip);
            // Her der skal være en linje kode med animatoren fra main camera så hver gang man bliver ramt så kommer der en animation
            EndlessCreator.movables.Remove(gameObject);
            Destroy(gameObject);
        }
        else
        {
            animator.SetBool("isHit", false);
            isHit = false;
        }
    }
}
    