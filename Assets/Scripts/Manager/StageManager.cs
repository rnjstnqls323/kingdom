using UnityEngine;

public class StageManager: MonoBehaviour
{
    WorldData _worldData;
    private PoolingManager _stageButtons;
    GameObject _buttonParent;

    private void Start()
    {
        Init(100);
    }
    private void Init(int stageNum)
    {
        _buttonParent = GameObject.Find("Buttons");
        _worldData = DataManager.Instance.GetWorldData(stageNum);
        
        CreateStageButtons(); // Ǯ������ �����Ŀ� ���ֱ� (�̶�, ���� �Ѱܼ� ���� �����ϱ�)
        ChangeBackGround();
    }

    private void CreateStageButtons()
    {
        _stageButtons = new PoolingManager("Prefabs/StageButton", _buttonParent, 10);

        for(int i = 1; i <= _worldData.StageNum; i++)
        {
            StageButton obj = _stageButtons.Pop().GetComponent<StageButton>();
            obj.Data = DataManager.Instance.GetStageData(_worldData.Key + i);
            obj.SetInformation();
        }
    }
    private void ChangeBackGround()
    {
        GameObject bg = GameObject.Find("Background");
        SpriteRenderer bgRenderer = bg.GetComponent<SpriteRenderer>();
        Sprite sprite = Resources.Load<Sprite>(_worldData.BgImage);
        bgRenderer.sprite = sprite;
    }
}
