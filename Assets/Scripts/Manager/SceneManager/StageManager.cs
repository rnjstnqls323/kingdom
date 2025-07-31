using UnityEngine;

public class StageManager: MonoBehaviour
{
    private WorldData _worldData;
    private PoolingManager _stageButtons;
    private GameObject _buttonParent;

    private void Start()
    {
        Init(100); // �̰� �� �Ѱ���ߵǴµ�
    }
    private void Init(int stageNum)
    {
        _buttonParent = GameObject.Find("Buttons");
        _worldData = WorldDataManager.Instance.GetWorldData();
        
        CreateStageButtons(); // Ǯ������ �����Ŀ� ���ֱ� (�̶�, ���� �Ѱܼ� ���� �����ϱ�)
        ChangeBackGround();
    }

    private void CreateStageButtons()
    {
        _stageButtons = new PoolingManager("Prefabs/Buttons/StageButton", _buttonParent, 10);

        for(int i = 1; i <= _worldData.StageNum; i++)
        {
            StageButton obj = _stageButtons.Pop().GetComponent<StageButton>();
            obj.Data = WorldDataManager.Instance.GetStageData(_worldData.Key + i);
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
