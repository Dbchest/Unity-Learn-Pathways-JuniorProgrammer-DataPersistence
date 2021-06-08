using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class Persistence : MonoSingleton<Persistence>
{
    private readonly BinaryFormatter formatter = new BinaryFormatter();

    private BinaryFormatter Formatter
    {
        get { return formatter; }
    }

    public string Directory
    {
        get { return Application.persistentDataPath; }
    }

    public string DeterminePath(string filename)
    {
        return string.Format("{0}/{1}.dat", Directory, filename);
    }

    public void Save()
    {
        SaveHighScore();
    }

    public void Load()
    {
        LoadHighScore();
    }

    internal void DeleteHighScore()
    {
        var filename = HighScore.Instance.GetType().Name;
        var path = DeterminePath(filename);

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    private void Start()
    {
        Load();
    }

    private void SaveHighScore()
    {
        var data = HighScore.Instance.CreateData();
        var filename = HighScore.Instance.GetType().Name;
        var path = DeterminePath(filename);

        var file = File.Create(path);
        Formatter.Serialize(file, data);
        file.Close();
    }

    private void LoadHighScore()
    {
        var filename = HighScore.Instance.GetType().Name;
        var path = DeterminePath(filename);

        if (File.Exists(path))
        {
            var file = File.Open(path, FileMode.Open);
            var data = (HighScoreData)Formatter.Deserialize(file);

            HighScore.Instance.Set(data.Points);
            HighScore.Instance.Identify(data.Id);
        }
    }
}