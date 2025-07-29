using TMPro;
using UnityEngine;

public class BattleTimer : MonoBehaviour
{
    public TextMeshProUGUI timeText; // Inspector���� TimeText ������Ʈ ����

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = (int)(elapsedTime / 60f);
        int seconds = (int)(elapsedTime % 60f);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
