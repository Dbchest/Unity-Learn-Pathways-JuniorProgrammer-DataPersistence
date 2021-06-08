[System.Serializable]
public class HighScoreData
{
    private readonly int points = 0;

    private readonly string id = string.Empty;

    public HighScoreData(HighScore instance)
    {
        points = instance.Points;
        id = instance.Id;
    }

    public int Points
    {
        get { return points; }
    }

    public string Id
    {
        get { return id; }
    }
}