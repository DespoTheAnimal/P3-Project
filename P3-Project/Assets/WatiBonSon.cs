using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class WatiBonSon : MonoBehaviour
{
    [SerializeField] private AudioSource watiBonSon;
    [SerializeField] private AudioClip startScreenSong;
    [SerializeField] private AudioClip inGameSong;
    [SerializeField] private AudioClip endScreenSong;
    private bool isPlaying = false;
    private bool isDead = false;

    void Start()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(startScreenSong);
        DontDestroyOnLoad(inGameSong);
        DontDestroyOnLoad(watiBonSon);
        DontDestroyOnLoad(endScreenSong);
        watiBonSon.clip = startScreenSong;
        watiBonSon.Play();
        watiBonSon.volume = 0.5f;
    }


    void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        //Actual game scenes after tutorial
        if (y >= 2 && !isPlaying)
        {
            watiBonSon.Stop();
            watiBonSon.clip = inGameSong;
            watiBonSon.PlayOneShot(inGameSong);
            isPlaying = true;
        }

        //Deathscene music
        if (y == 2 && !isDead)
        {
            watiBonSon.Stop();
            watiBonSon.clip = endScreenSong;
            watiBonSon.PlayOneShot(endScreenSong);
            isDead = true;
        }
    }
}
