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
    [SerializeField] private AudioClip deathScreenSong;
    [SerializeField] private AudioClip winScreenSong;
    private bool isPlaying = false;
    private bool isDead = false;

    void Start()
    {
        watiBonSon.volume = 0.3f;
        watiBonSon.Play();
        watiBonSon.loop = true;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(startScreenSong);
        DontDestroyOnLoad(inGameSong);
        DontDestroyOnLoad(watiBonSon);
        DontDestroyOnLoad(deathScreenSong);
        DontDestroyOnLoad(winScreenSong);
        watiBonSon.clip = startScreenSong;
    }


    void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        if (y == 1 && y !>= 2 && !isPlaying)
        {
            watiBonSon.Play();
        }


        //Actual game scenes after tutorial
        if (y == 3 && y < 11 && !isPlaying)
        {
            watiBonSon.Stop();
            watiBonSon.clip = inGameSong;
            watiBonSon.Play();
            watiBonSon.loop = true;
            isPlaying = true;
        }

        //Deathscene music
        if (y == 2 && !isDead)
        {
            watiBonSon.Stop();
            watiBonSon.clip = deathScreenSong;
            watiBonSon.Play();
            isDead = true;
        }

        //Winscene music
        if (y == 11 && !isDead)
        {
            isPlaying = false;
            watiBonSon.Stop();
            watiBonSon.clip = winScreenSong;
            watiBonSon.Play();
            isDead = true;
        }
        if (y == 12)
        {
            watiBonSon.Pause();
        }
    }
}
