using System;

[Serializable]
public class ActualHighScoreSystem
{
    public string playerName;
    public int points;

    public ActualHighScoreSystem(string name, int points)
    {
        playerName = name;
        this.points = points; 
    }
}
