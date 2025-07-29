﻿using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterManager : Singleton<CharacterManager>
{
    private List<int> _setCharacterList = new List<int>();
    private int _characterCount = 0;
    private int[,] _characterArr = new int[3,3];

    public List<int> Character
    { get { return _setCharacterList; } }

    public void SetCharacter(int key)
    {
        if (_characterCount == 5) return;
        _characterCount++;
        CookieData cookie = DataManager.Instance.GetCookieData(key);
        
        switch (cookie.Type)
        {
            case 1: //전방
                SettingPosition(2,key);
                break;
            case 2: //중앙
                SettingPosition(1, key);
                break;
            case 3://후방
                SettingPosition(0, key);
                break;

        }

        Debug.Log(_characterArr[0, 0] + "|" + _characterArr[0, 1] + "|" + _characterArr[0, 2]);
        Debug.Log(_characterArr[1, 0] + "|" + _characterArr[1, 1] + "|" + _characterArr[1, 2]);
        Debug.Log(_characterArr[2, 0] + "|" + _characterArr[2, 1] + "|" + _characterArr[2, 2]);
        Debug.Log("---------------------------------------------------");
    }

    public void SetOffCharacter(int key)
    {
        _characterCount--;
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                if (_characterArr[y, x] == key)
                {
                    _characterArr[y, x] = 0;
                    SetOffPosition(y,x);
                    //return;
                }

        Debug.Log(_characterArr[0, 0] + "|" + _characterArr[0, 1] + "|" + _characterArr[0, 2]);
        Debug.Log(_characterArr[1, 0] + "|" + _characterArr[1, 1] + "|" + _characterArr[1, 2]);
        Debug.Log(_characterArr[2, 0] + "|" + _characterArr[2, 1] + "|" + _characterArr[2, 2]);
        Debug.Log("---------------------------------------------------");
    }
    public void ResetAll()
    {
        for (int y = 0; y < 3; y++)
            for (int x = 0; x < 3; x++)
                _characterArr[y,x] = 0;
    }

    private void SetOffPosition(int y,int x)
    {
        if (y == 1) return;
        else if(y == 2)
        {
            _characterArr[1,x] = _characterArr[0, x];
            _characterArr[0, x] = 0;
        }
        else
        {
            _characterArr[1,x] = _characterArr[2, x];
            _characterArr[2, x] = 0;
        }
    }
    private void SettingPosition(int num, int key)
    {

        if (_characterArr[1,num] == 0 && _characterArr[0,num] == 0)
        {
            _characterArr[1, num] = key;
            return;
        }
        else if (_characterArr[1, num]!=0)
        {
            CharacterData originData = DataManager.Instance.GetCharacterData(_characterArr[1, num]);
            CharacterData keyData = DataManager.Instance.GetCharacterData(key);

            if (originData.Defense>keyData.Defense)
            {
                _characterArr[0, num] = _characterArr[1, num];
                _characterArr[1, num] = 0;
                _characterArr[2, num] = key;
            }
            else
            {
                _characterArr[0, num] = key;
                _characterArr[2, num] = _characterArr[1, num];
                _characterArr[1, num] = 0;
            }
            return;
        }

        if(num>0)
        {
            List<CharacterData> data = new List<CharacterData>();
            data[0] = DataManager.Instance.GetCharacterData(_characterArr[0, num]);
            data[1] = DataManager.Instance.GetCharacterData(_characterArr[2, num]);
            data[2] = DataManager.Instance.GetCharacterData(key);
            float min = 1000;
            int temp = key;
            
            foreach(CharacterData dt in data)
            {
                if(dt.Defense < min)
                {
                    min = dt.Defense;
                    temp = dt.Key;
                }
            }
            SettingPosition(num - 1, temp);
            return;
        }
        else
        {
            List<CharacterData> data = new List<CharacterData>();
            data[0] = DataManager.Instance.GetCharacterData(_characterArr[0, num]);
            data[1] = DataManager.Instance.GetCharacterData(_characterArr[2, num]);
            data[2] = DataManager.Instance.GetCharacterData(key);
            float max = 0;
            int temp = key;

            foreach (CharacterData dt in data)
            {
                if (dt.Defense > max)
                {
                    max = dt.Defense;
                    temp = dt.Key;
                }
            }
            SettingPosition(num + 1, temp);
            return;
        }
    }
}