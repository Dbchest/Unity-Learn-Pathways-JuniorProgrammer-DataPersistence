public class Score : MonoSingleton<Score>
{
    private int points = 0;

    public static System.Action Adding;

    public static System.Action Added;

    public int Points
    {
        get { return points; }
        private set { points = value; }
    }

    public void Add(int points)
    {
        Adding?.Invoke();

        Points += points;

        Added?.Invoke();
    }

    internal void Initialize()
    {
        Points = 0;
    }
}