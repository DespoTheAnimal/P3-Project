using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreThingy : MonoBehaviour
{
    //Mangler bare lige at lave et par TMP elementer, og sætte dem lig med highScore1-5 for display
    private int placeHolder;
    private TextMeshProUGUI highScore1, highScore2, highScore3, highScore4, highScore5;
    private List<int> highScores = new List<int>();
    private List<TextMeshProUGUI> textFields = new List<TextMeshProUGUI>();


    public TextMeshProUGUI HighScoreTMP;

    private void Awake()
    {
        placeHolder = PlayerPrefs.GetInt("NewScore");
        Debug.Log(placeHolder);
        //ListHighScores();
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            highScores.Add(0);
        }
    }

    private void StoreHighScore()
    {
        for (int i = 0; i <5; i++)
        {
            PlayerPrefs.SetInt("score" + i, highScores[i]);
        }
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("score" + i))
            {
                highScores[i] = PlayerPrefs.GetInt("score" + i);
            }
        }
    }


    private void AddHighScores(string name, int val)
    {
        bool inserted = false;

        for (int i = 0; i < 5 && !inserted; i++)
        {
            if (val > highScores[i])
            {
                highScores.Insert(i, val);
            }
        }
        if (highScores.Count > 5)
        {
            highScores.RemoveAt(5);
        }
        StoreHighScore();
    }

    public void FillInHighScores()
    {
        HighScoreTMP.text = "List of the 5 Highest Scores:";

    }

    /*
    private void ListHighScores()
    {
        highScores.Add(placeHolder);
        highScores.Sort();
        //Velkommen til det vildeste Spaghetti-Western code...
        highScore1 = highScores[0];
        highScore2 = highScores[1];
        highScore3 = highScores[2];
        highScore4 = highScores[3];
        highScore5 = highScores[4];
    }*/

}
