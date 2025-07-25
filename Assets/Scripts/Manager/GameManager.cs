using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //스테이지 시작하면 스테이지매니저 부르기
    private void Start()
    {
        DataManager.Instance.LoadAllData();
        StageManager stageManager = new StageManager();
        stageManager.Init(100);
    }
}
