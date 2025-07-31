using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;

public class WorldDataManager:Singleton<WorldDataManager>
{
    private Dictionary<int,WorldData> _worldData;
    private Dictionary<int,StageData> _stageData;
    private int _worldKey;
    private int _stageKey;

    public int WorldKey
    {
        get { return _worldKey; }
        set { _worldKey = value; }
    }
    public int StageKey
    {
        get { return _stageKey; }
        set { _stageKey = value; }
    }
    public WorldData GetWorldData()
    {
        return _worldData[_worldKey];
    }
    public StageData GetStageData()
    {
        return _stageData[_stageKey];
    }
    public StageData GetStageData(int key)
    {
        return _stageData[_stageKey];
    }

    public void SetData()
    {
        _worldData = DataManager.Instance.GetAllWorldData();
        _stageData = DataManager.Instance.GetAllStageData();
    }

}
