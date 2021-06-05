using UnityEngine;

public class User : MonoBehaviour
{
    public static User Instance { get; private set; }

    ////private string name;

    ////private int score;

    public string Name { get; set; }

    public int Score { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}