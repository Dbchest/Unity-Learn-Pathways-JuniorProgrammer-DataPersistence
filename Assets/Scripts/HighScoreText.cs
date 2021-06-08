using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour
{
    private Text highScore;

    private string Points
    {
        get { return HighScore.Instance.Points.ToString(); }
    }

    private string Id
    {
        get { return HighScore.Instance.Id; }
    }

    private string Message
    {
        get { return " has the high score: "; }
    }

    private string Text
    {
        get { return string.Format("{0}{1}{2}", Id, Message, Points); }
    }

    private void Awake()
    {
        highScore = GetComponent<Text>();
    }

    private void Start()
    {
        highScore.text = Text;
    }
}