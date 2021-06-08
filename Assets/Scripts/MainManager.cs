using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    ////public GameObject GameOverText;

    ////private int m_Points;

    private bool m_Started = false;
    private bool m_GameOver = false;

    // custom fields

    [SerializeField]
    private GameObject highScoreText;

    [SerializeField]
    private GameObject gameOverCanvasGroup;

    [SerializeField]
    private GameObject pressSpaceKeyText;

    [SerializeField]
    private GameObject highScoreVerticalLayoutGroup;

    private bool isNewHighScore = false;

    public void GameOver()
    {
        m_GameOver = true;
        ////GameOverText.SetActive(true);

        // custom processing

        gameOverCanvasGroup.SetActive(true);

        if (isNewHighScore)
        {
            pressSpaceKeyText.SetActive(false);
            highScoreVerticalLayoutGroup.SetActive(true);
        }

        else
        {
            pressSpaceKeyText.SetActive(true);
            highScoreVerticalLayoutGroup.SetActive(false);
        }
    }

    private void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        // custom processing

        var isHighScore = HighScore.Instance.Points > 0;
        var isIdentified = !string.IsNullOrEmpty(HighScore.Instance.Id);

        if (isHighScore && isIdentified)
        {
            highScoreText.SetActive(true);
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }

        else if (m_GameOver)
        {
            if (!isNewHighScore && Input.GetKeyDown(KeyCode.Space))
            {
                var sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }

    private void AddPoint(int point)
    {
        /* m_Points += point;
        ScoreText.text = $"Score : {m_Points}"; */

        // custom processing

        Score.Instance.Add(point);
        ScoreText.text = string.Format("Score: {0}", Score.Instance.Points);
    }

    // custom methods

    public void ResolveHighScoreId(string id)
    {
        HighScore.Instance.Identify(id);
    }

    private void OnEnable()
    {
        HighScore.Changed += QueueHighScoreId;
        HighScore.Identified += SaveHighScore;
        HighScore.Identified += Restart;
    }

    private void QueueHighScoreId()
    {
        isNewHighScore = true;
    }

    private void SaveHighScore()
    {
        Persistence.Instance.Save();
    }

    private void Restart()
    {
        Score.Instance.Initialize();

        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnDisable()
    {
        HighScore.Changed -= QueueHighScoreId;
        HighScore.Identified -= SaveHighScore;
        HighScore.Identified -= Restart;
    }
}