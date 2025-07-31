using UnityEngine;
using System.Collections.Generic;
public class WideHeal : Skills
{
    protected override void UseSkill(CharacterData owner)
    {
        //�ӽ�
        List<CharacterData> charList = DataManager.Instance.GetAllCharacterData();
        for (int i = 0; i < charList.Count; ++i)
        {
            CharacterData charData = charList[i];
            if (charData.Key <= 0) continue;

            float healAmount = charData.Attack * 0.5f;
            charData.Hp += healAmount;

            Debug.Log($"{charData.Name}�� {healAmount}��ŭ ȸ��! (����ü��: {charData.Hp})");
        }

    }
}
// ��Ƽ�� ����ִ� ��� ĳ���� ��ȸ
//List<int> keyList = CharacterManager.Instance.Character;
//for (int i = 0; i < keyList.Count; ++i)
//{
//    int charKey = keyList[i];
//    if (charKey <= 0) continue; // ��ĭ ��ŵ
//
//    CharacterData charData = DataManager.Instance.GetCharacterData(charKey);
//
//    float healAmount = charData.Attack * 0.5f; // �� ĳ������ ���ݷ� ��� ��
//    charData.Hp += healAmount;
//
//    Debug.Log($"{charData.Name}�� {healAmount}��ŭ ȸ��! (����ü��: {charData.Hp})");
//}

//�ӽ��ڵ�
//owner.Hp += healAmount;
//Debug.Log("�Ʊ��� {healAmount} ��ŭ ȸ��");