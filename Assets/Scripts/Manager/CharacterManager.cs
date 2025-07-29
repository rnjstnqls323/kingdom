using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct Index2
{
    public int y;
    public int x;
    public Index2(int y, int x)
    {
        this.y = y; 
        this.x = x;
    }
    //필요없을듯
}

public class CharacterManager : Singleton<CharacterManager>
{
    //일단 3*3 으로 잡고 캐릭터 배치하자 애초에 리스트로 안넘겨도되겠네

    private List<int> _setCharacterList = new List<int>(); 

    public List<int> Character
    { get { return _setCharacterList; } }

    public void SetCharacter(int key)
    {
        bool isInsert = false;
        CharacterData data = DataManager.Instance.GetCharacterData(key);
        int count = -1;
        foreach (int node in _setCharacterList)
        {
            count++;
            CharacterData nodeData = DataManager.Instance.GetCharacterData(node);

            if (data.Defense <= nodeData.Defense) continue;

            _setCharacterList.Insert(count, key);
            isInsert = true;
            break;
        }
        if(!isInsert)
            _setCharacterList.Add(key);

        foreach (int i in _setCharacterList)
        {
            Debug.Log(i+"/"+DataManager.Instance.GetCharacterData(i).Defense);
        }
    }
    public void SetOffCharacter(int key)
    {
        _setCharacterList.Remove(key);
        foreach (int i in _setCharacterList)
        {
            Debug.Log(i);
        }
    }
    public void ResetAll()
    {
        _setCharacterList.Clear();

    }
}