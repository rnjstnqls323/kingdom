using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;

public class InventoryManager : Singleton<InventoryManager>
{
    private Dictionary<int,InventoryData> _data;


    public void AddData(InventoryData data)
    {
        _data[data.Key] = data;
    }
    public void SetData() //���ӸŴ������� ���ֱ�
    {
        _data = DataManager.Instance.GetAllHaveCookieData();
    }
    public void CookieLevelUp(int key)
    {
        _data[key].LevelUp();
    }
    public InventoryData GetData(int key)
    {
        return _data[key];
    }
    public List<InventoryData> GetAllHaveCookieData()
    {
        List<InventoryData> list = new List<InventoryData>();
        foreach (InventoryData data in _data.Values)
        {
            list.Add(data);
        }
        return list;
    }

}
