using UnityEngine;

[RequireComponent(typeof(ScenePersistence))]
public abstract class MonoSingleton<TMonoSingleton> : MonoBehaviour
    where TMonoSingleton : MonoSingleton<TMonoSingleton>
{
    private static TMonoSingleton instance;

    public static TMonoSingleton Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = (TMonoSingleton)this;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}