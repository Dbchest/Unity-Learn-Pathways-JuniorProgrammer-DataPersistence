using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartBehaviour : MonoBehaviour
{
    [SerializeField]
    private InputField username;

    public void UpdateUsername()
    {
        if (username.text == string.Empty)
        {
            username.text = "Guest";
        }

        User.Instance.Name = username.text;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("main");
    }
}