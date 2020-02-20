using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                    Debug.LogError($"_instance of type({typeof(T)}) do not exist");
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        T thisInstance = gameObject.GetComponent<T>();
        if (_instance != null && _instance != thisInstance)
        {
            Debug.LogError($"_instance for type({typeof(T)}) already exis. {gameObject.name} Destroyed (Duplicate)");
            Destroy(gameObject);
            return;
        }

        _instance = thisInstance;
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
            _instance = null;
    }
}
