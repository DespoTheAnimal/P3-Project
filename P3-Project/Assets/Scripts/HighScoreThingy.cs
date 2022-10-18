using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreThingy : MonoBehaviour
{
    //Mangler bare lige at lave et par TMP elementer, og sætte dem lig med highScore1-5 for display
    private int placeHolder;
    private int highScore1, highScore2, highScore3, highScore4, highScore5;
    private List<int> highScores = new List<int>();

    private void Awake()
    {
        placeHolder = PlayerPrefs.GetInt("NewScore");
        Debug.Log(placeHolder);
        ListHighScores();
    }

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
    }

}
