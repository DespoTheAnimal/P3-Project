using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    List<ActualHighScoreSystem> highscoreList = new List<ActualHighScoreSystem>();
    [SerializeField] int maxCount = 5;

    private void Start()
    {
        LoadHighscores(); 
    }

    private void LoadHighscores()
    {

    }

    private void SaveHighscore()
    {

    }
    public void AddHighscoreIfPossible(ActualHighScoreSystem element)
    {

    }
}
