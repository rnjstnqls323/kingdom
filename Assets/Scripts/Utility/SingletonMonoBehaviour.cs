using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // ������ �̹� �����ϴ� �ν��Ͻ��� �ִ��� �˻�
                _instance = FindAnyObjectByType<T>();

                if (_instance == null)
                {
                    // ������ �� GameObject ���� �� ������Ʈ �߰�
                    GameObject singletonObj = new GameObject(typeof(T).Name + " (Singleton)");
                    _instance = singletonObj.AddComponent<T>();
                    DontDestroyOnLoad(singletonObj);
                }
            }

            return _instance;
        }
    }

    // �ߺ� ����
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
}
