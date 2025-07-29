using UnityEngine;

public class SkillButtonManager : MonoBehaviour
{
    void Start()
    {
        // 1. ������ Resources���� �ε� (Resources/Prefabs/SkillButton)
        GameObject skillButtonPrefab = Resources.Load<GameObject>("Prefabs/SkillButton");
        if (skillButtonPrefab == null)
        {
            return;
        }

        // 2. SkillButtons �θ� ������Ʈ ã��
        GameObject skillButtonsParentObj = GameObject.Find("SkillButtons");
        if (skillButtonsParentObj == null)
        {
            return;
        }
        Transform skillButtonsParent = skillButtonsParentObj.transform;

        // 3. ��ư 5�� �����ؼ� ��޺� ��� ����
        for (int i = 0; i < 5; ++i)
        {
            GameObject btnObj = Instantiate(skillButtonPrefab, skillButtonsParent);
            SkillButton btn = btnObj.GetComponent<SkillButton>();
            // 0: Common, 1: Rare, 2: Epic, 3: Legendary, 4: Common �ݺ�
            btn.SetGrade((SkillButton.Grade)(i % 4));
        }
    }
}
