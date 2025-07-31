using UnityEngine;

public class HealSkillTest : MonoBehaviour
{
    public float maxHp = 100;
    public float curHp = 60;
    public float attack = 40;

    private WideHeal healSkill;

    void Start()
    {
        // �ӽ� ĳ���� ������ ����
        CharacterData data = new CharacterData
        {
            Name = "�ӽ���Ű",
            Hp = maxHp,
            Attack = attack,
        };

        healSkill = new WideHeal();
        healSkill.Init("����ų", 5.0f);

        // ó�� ���� ���
        Debug.Log($"[�ʱ�] {data.Name} ����ü��: {curHp}/{data.Hp}");
    }

    [ContextMenu("�� �׽�Ʈ!")]
    public void TestHeal()
    {
        // �ӽ� ĳ���� ������ ����
        CharacterData data = new CharacterData
        {
            Name = "�ӽ���Ű",
            Hp = maxHp,
            Attack = attack,
        };

        // �� ����
        float healAmount = data.Attack * 0.5f;
        curHp += healAmount;
        if (curHp > data.Hp)
            curHp = data.Hp;

        Debug.Log($"�� ����! {data.Name}��(��) {healAmount}��ŭ ȸ��! (����: {curHp}/{data.Hp})");
    }
}
