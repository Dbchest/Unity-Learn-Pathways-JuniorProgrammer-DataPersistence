using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject highScoreText;

    public void LoadMainScene()
    {
        SceneManager.LoadScene("main");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        var isHighScore = HighScore.Instance.Points > 0;
        var isIdentified = !string.IsNullOrEmpty(HighScore.Instance.Id);

        if (isHighScore && isIdentified)
        {
            highScoreText.SetActive(true);
        }
    }
}