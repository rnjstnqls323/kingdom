using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public RectTransform barImage;      // BarImage RectTransform
    public RectTransform progressIcon;  // ProgressIcon RectTransform

    // ���� �ð� (����: 10�� ���� 100% ����)
    public float totalTime = 10f;
    private float curTime = 0f;

    void Update()
    {
        // �׽�Ʈ��: �ð��� ���� 0~1�� ����
        if (curTime < totalTime)
        {
            curTime += Time.deltaTime;
            float progress = Mathf.Clamp01(curTime / totalTime);
            SetProgress(progress);
        }
    }

    public void SetProgress(float progress)
    {
        progress = Mathf.Clamp01(progress);

        // progress 0�� �� -halfBar, 1�� �� +halfBar
        float x = Mathf.Lerp(0, barImage.rect.width, progress);

        progressIcon.anchoredPosition = new Vector2(x, progressIcon.anchoredPosition.y);
    }
}
