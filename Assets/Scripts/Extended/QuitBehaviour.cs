#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

public class QuitBehaviour : MonoBehaviour
{
    public void Quit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif

        Application.Quit();
    }
}