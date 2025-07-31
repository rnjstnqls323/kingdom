using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonManager : MonoBehaviour
{
    public GameObject skillButtonPrefab;
    public Transform skillButtonsParent;

    void Start()
    {
        DataManager.Instance.LoadAllData();

        // �� ��ü ĳ���� ������ �������� ��ư ���� ��
        List<CharacterData> charList = DataManager.Instance.GetAllCharacterData();
        for (int i = 0; i < charList.Count; ++i)
        {
            CharacterData charData = charList[i];

            // �� ���� üũ(�ʿ��, �ƴϸ� ���� ����)
            if (charData.Key <= 0) continue;

            GameObject btnObj = Instantiate(skillButtonPrefab, skillButtonsParent);
            SkillButton btn = btnObj.GetComponent<SkillButton>();

            // ��޺� UI ����
            SkillButton.Grade gradeEnum = SkillManager.Instance.GradeStringToEnum(charData.Grade);
            btn.SetGrade(gradeEnum);
            btn.StartCooldown(0);

            // ��ų �ν��Ͻ� ���� (���丮+�ʱ�ȭ)
            Skills skill = SkillManager.Instance.CreateSkill(charData.SkillName, charData.Cooltime);

            // Ŭ���� ����
            CharacterData capturedCharData = charData;
            SkillButton capturedBtn = btn;
            Skills capturedSkill = skill;

            Button uiButton = btnObj.GetComponent<Button>();
            uiButton.onClick.AddListener(() =>
            {
                capturedBtn.StartCooldown(capturedCharData.Cooltime);

                if (capturedSkill != null)
                    capturedSkill.CheckSkill(capturedCharData);
                else
                    Debug.LogWarning($"��ų ����: {capturedCharData.SkillName}");
            });
        }
    }
}


//{
//    public GameObject skillButtonPrefab;
//    public Transform skillButtonsParent;
//
//    void Start()
//    {
//        // ������ �ε�
//        DataManager.Instance.LoadAllData();
//
//        // ��Ƽ�� ��ġ�� ĳ���� Ű ����Ʈ (CharacterManager���� ������)
//        List<int> charKeyList = CharacterManager.Instance.Character;
//        for (int i = 0; i < charKeyList.Count; ++i)
//        {
//            int charKey = charKeyList[i];
//            if (charKey <= 0) continue; // �� ���� ��ŵ
//
//            CharacterData charData = DataManager.Instance.GetCharacterData(charKey);
//
//            // ��ư ������ ����
//            GameObject btnObj = Instantiate(skillButtonPrefab, skillButtonsParent);
//            SkillButton btn = btnObj.GetComponent<SkillButton>();
//
//            // ��޺� UI ����
//            SkillButton.Grade gradeEnum = SkillManager.Instance.GradeStringToEnum(charData.Grade);
//            btn.SetGrade(gradeEnum);
//            btn.StartCooldown(0);
//
//            // �� ĳ������ ��ų ���� (���丮 + �ʱ�ȭ)
//            Skills skill = SkillManager.Instance.CreateSkill(charData.SkillName, charData.Cooltime);
//
//            // Ŭ�� �̺�Ʈ (���� Ŭ���� ĸó! �ݵ�� ���纻)
//            CharacterData capturedCharData = charData;
//            SkillButton capturedBtn = btn;
//            Skills capturedSkill = skill;
//
//            Button uiButton = btnObj.GetComponent<Button>();
//            uiButton.onClick.AddListener(() =>
//            {
//                // ��Ÿ�� UI
//                capturedBtn.StartCooldown(capturedCharData.Cooltime);
//
//                // ��Ÿ��/���� üũ & ��ų ����
//                if (capturedSkill != null)
//                    capturedSkill.CheckSkill(capturedCharData);
//                else
//                    Debug.LogWarning($"��ų ����: {capturedCharData.SkillName}");
//            });
//        }
//    }
//}
