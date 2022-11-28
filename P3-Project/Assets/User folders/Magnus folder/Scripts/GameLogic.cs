using OpenCvSharp;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{

    public static int lives;
    public TextMeshProUGUI text;
    public GameObject[] Hearts;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("livesPrefs");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        LoseCondition();
        PlayerPrefs.SetInt("livesPrefs", lives);
    }

    void UpdateHealth()
    {
        if (lives < 1)
        {
            Destroy(Hearts[0].gameObject);
            Destroy(Hearts[1].gameObject);
            Destroy(Hearts[2].gameObject);
        }
        else if (lives < 2)
        {
            Destroy(Hearts[1].gameObject);
            Destroy(Hearts[2].gameObject);
        }
        else if (lives < 3)
        {
            Destroy(Hearts[2].gameObject);
        }
    }

    void LoseCondition()
    {
        if (lives <= 0)
        {
            PlayerPrefs.SetInt("NewScore", score);
            SceneManager.LoadScene("YouDied");
        }
    }

}
