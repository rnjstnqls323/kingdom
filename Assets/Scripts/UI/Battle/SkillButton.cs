using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButton : MonoBehaviour
{
    public enum Grade { Common, Rare, Epic, Legendary }

    [Header("UI")]
    [SerializeField] private Image bgImage;         // Inspector���� ������ ��� ����
    [SerializeField] private Image cooldownFill;    // Inspector���� ��Ÿ�� �������� ���� (������, Filled)
    [SerializeField] private TMP_Text cooldownText; // Inspector���� ��Ÿ�� �ؽ�Ʈ ����

    private Sprite[] backgroundSprites; // ��޺� Sprite �ڵ忡�� �ε�
    private Sprite[] cooldownFillSprites;

    private float cooldownDuration;
    private float cooldownTimer;
    private bool isCooldown = false;

    void Awake()
    {
        // ��޺� ��� ��������Ʈ Resources���� �ڵ�θ� �ε�
        backgroundSprites = new Sprite[4];
        backgroundSprites[0] = Resources.Load<Sprite>("Textures/BattleScene/CommonBack");
        backgroundSprites[1] = Resources.Load<Sprite>("Textures/BattleScene/RareBack");
        backgroundSprites[2] = Resources.Load<Sprite>("Textures/BattleScene/EpicBack");
        backgroundSprites[3] = Resources.Load<Sprite>("Textures/BattleScene/LegendaryBack");
        cooldownFillSprites = new Sprite[4];
        cooldownFillSprites[0] = Resources.Load<Sprite>("Textures/BattleScene/Common");
        cooldownFillSprites[1] = Resources.Load<Sprite>("Textures/BattleScene/Rare");
        cooldownFillSprites[2] = Resources.Load<Sprite>("Textures/BattleScene/Epic");
        cooldownFillSprites[3] = Resources.Load<Sprite>("Textures/BattleScene/Legendary");
        if (cooldownFill) cooldownFill.gameObject.SetActive(false);
        if (cooldownText) cooldownText.gameObject.SetActive(false);
    }

    // ��޺��� ��� ��ü (Inspector���� bgImage�� ���������� �����صΰ� ���⼭ Sprite�� �ٲ�)
    public void SetGrade(Grade grade)
    {
        int idx = (int)grade;
        if (backgroundSprites != null && idx >= 0 && idx < backgroundSprites.Length && bgImage)
            bgImage.sprite = backgroundSprites[idx];
        if (cooldownFillSprites != null && idx >= 0 && idx < cooldownFillSprites.Length && cooldownFill)
            cooldownFill.sprite = cooldownFillSprites[idx];
    }

    //�ܺο��� ��Ÿ�� ������ �� ȣ��
    public void StartCooldown(float duration)
    {
        cooldownDuration = duration;
        cooldownTimer = cooldownDuration;
        isCooldown = true;

        if (cooldownFill) cooldownFill.gameObject.SetActive(true);
        if (cooldownText) cooldownText.gameObject.SetActive(true);

        UpdateCooldownUI();
    }

    void Update()
    {
        if (!isCooldown) return;

        cooldownTimer -= Time.deltaTime;
        UpdateCooldownUI();

        if (cooldownTimer <= 0)
        {
            isCooldown = false;
            if (cooldownText) cooldownText.gameObject.SetActive(false);
        }
    }

    private void UpdateCooldownUI()
    {
        if (cooldownFill)
        {
            float ratio = Mathf.Clamp01(cooldownTimer / cooldownDuration);
            cooldownFill.fillAmount = ratio;

            Color c = cooldownFill.color;
            c.a = (ratio > 0) ? 0.0f : 0.9f;
            cooldownFill.color = c;
        }

        if (cooldownText)
        {
            if (cooldownTimer > 0)
            {
                cooldownText.gameObject.SetActive(true);
                cooldownText.text = Mathf.CeilToInt(cooldownTimer).ToString();
            }
            else
            {
                cooldownText.gameObject.SetActive(false);
            }
        }
    }


    // ��ư Ŭ�� �� ��Ÿ�� �׽�Ʈ (�ӽ�/���߿�)
    public void OnClickSkill()
    {
        if (!isCooldown)
            StartCooldown(cooldownDuration); // ����: �̸� ���õ� ��Ÿ������ �ٽ� ����
    }
}
