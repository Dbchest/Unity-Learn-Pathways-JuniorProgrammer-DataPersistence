public class HighScore : MonoSingleton<HighScore>
{
    private int points = 0;

    private string id = string.Empty;

    public static System.Action Changing;

    public static System.Action Changed;

    public static System.Action Identifying;

    public static System.Action Identified;

    public int Points
    {
        get { return points; }
        private set { points = value; }
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
    }

    public void Identify(string id)
    {
        Identifying?.Invoke();

        Id = id;

        Identified?.Invoke();
    }

    public HighScoreData CreateData()
    {
        return new HighScoreData(this);
    }

    internal void Set(int points)
    {
        Changing?.Invoke();

        Points = points;

        Changed?.Invoke();
    }

    private void OnEnable()
    {
        Score.Added += CheckScore;
    }

    private void CheckScore()
    {
        if (Score.Instance.Points > Points)
        {
            Changing?.Invoke();

            Points = Score.Instance.Points;

            Changed?.Invoke();
        }
    }

    private void OnDisable()
    {
        Score.Added -= CheckScore;
    }
}