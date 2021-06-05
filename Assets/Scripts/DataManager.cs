using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    private BinaryFormatter formatter;

    public void Save()
    {
        var data = new Data();
        data.name = User.Instance.Name;
        data.score = User.Instance.Score;

        var directory = Application.persistentDataPath;
        var path = string.Format("{0}/user.dat", directory);

        var file = File.Create(path);
        formatter.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        var directory = Application.persistentDataPath;
        var path = string.Format("{0}/user.dat", directory);

        if (File.Exists(path))
        {
            var file = File.Open(path, FileMode.Open);
        }
    }

    private void Awake()
    {
        formatter = new BinaryFormatter();

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