using UnityEngine;

public class DebugGUI : MonoBehaviour
{
    [SerializeField]
    private Rect DeleteButtonRect;

    private void OnGUI()
    {
        if (GUI.Button(DeleteButtonRect, "Delete High Score"))
        {
            Persistence.Instance.DeleteHighScore();
        }
    }
}
