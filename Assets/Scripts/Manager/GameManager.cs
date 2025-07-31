using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //�������� �����ϸ� ���������Ŵ��� �θ���
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DataManager.Instance.LoadAllData();
        InventoryManager.Instance.SetData();
        WorldDataManager.Instance.SetData();
    }
}
