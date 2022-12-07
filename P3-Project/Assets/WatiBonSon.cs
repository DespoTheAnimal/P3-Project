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
        watiBonSon.Play();
        watiBonSon.volume = 0.5f;
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
        //Actual game scenes after tutorial
        if (y > 1 && !isPlaying)
        {
            watiBonSon.Stop();
            watiBonSon.clip = inGameSong;
            watiBonSon.PlayOneShot(inGameSong);
            watiBonSon.loop = true;
            isPlaying = true;
        }

        //Deathscene music
        if (y == 1 && !isDead)
        {
            watiBonSon.Stop();
            watiBonSon.clip = deathScreenSong;
            watiBonSon.PlayOneShot(deathScreenSong);
            isDead = true;
        }

        //Winscene music
        if (y == 10 && !isDead)
        {
            watiBonSon.Stop();
            watiBonSon.clip = deathScreenSong;
            watiBonSon.PlayOneShot(deathScreenSong);
            isDead = true;
        }
    }
}
