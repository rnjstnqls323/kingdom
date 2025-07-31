using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //�������� �����ϸ� ���������Ŵ��� �θ���
    private void Awake()
    {
        DataManager.Instance.LoadAllData();
        InventoryManager.Instance.SetData();
    }
}
