using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = GameObject.Find("[ " + typeof(T).Name + " ]");
                if (obj == null) obj = new GameObject("[ " + typeof(T).Name + " ]");
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<T>();
            }

            return instance;
        }
    }

    protected virtual void OnDestroy()
    {
        instance = null;
    }
}
