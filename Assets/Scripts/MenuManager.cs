using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
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

    public void Quit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif

        Application.Quit();
    }

    private void Start()
    {
        Load();
    }

    private void Load()
    {
        var directory = Application.persistentDataPath;
        var path = string.Format("{0}/savefile.dat", directory);

        if (File.Exists(path))
        {
            // code
        }
    }
}