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

    private Dictionary<int, int> _setCharacter = new Dictionary<int, int>(); 

    public Dictionary<int, int> Character
    { get { return _setCharacter; } }

    public void SetCharacter(int key, int depth)
    {
        _setCharacter[key] = depth;

        foreach (int i in _setCharacter.Keys)
        {
            Debug.Log(i);
        }
    }
    public void SetOffCharacter(int key)
    {
        _setCharacter.Remove(key);
        foreach (int i in _setCharacter.Keys)
        {
            Debug.Log(i);
        }
    }
    public void ResetAll()
    {
        _setCharacter.Clear();

    }
}