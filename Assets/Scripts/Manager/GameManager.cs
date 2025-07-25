using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //�������� �����ϸ� ���������Ŵ��� �θ���
    private void Start()
    {
        DataManager.Instance.LoadAllData();
        StageManager stageManager = new StageManager();
        stageManager.Init(100);
    }
}
