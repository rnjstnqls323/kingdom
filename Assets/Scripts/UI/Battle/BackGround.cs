using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform[] tilemaps;
    public Camera mainCamera;
    public float tileSizeX = 1f;
    public float tileSizeY = 0.5f;
    public int mapWidth = 86;
    public float moveSpeed = 2f;

    private Vector3 moveDir;
    private Vector3 loopOffset;

    void Start()
    {
        moveDir = new Vector3(tileSizeX, tileSizeY, 0).normalized;
        loopOffset = new Vector3(tileSizeX * mapWidth, tileSizeY * mapWidth, 0);

        tilemaps[0].position = Vector3.zero;
        tilemaps[1].position = loopOffset;

        if (mainCamera != null)
            mainCamera.transform.position = new Vector3(0, 0, mainCamera.transform.position.z);
    }

    void Update()
    {
        Vector3 delta = moveDir * moveSpeed * Time.deltaTime;

        // ī�޶�� ������
        if (mainCamera != null)
            mainCamera.transform.position += new Vector3(delta.x, delta.y, 0);

        // ����� �ڷ�
        for (int i = 0; i < tilemaps.Length; i++)
            tilemaps[i].position -= delta;

        // ���� üũ (��Ȯ�� ����!)
        for (int i = 0; i < tilemaps.Length; i++)
        {
            Transform cur = tilemaps[i];
            Transform other = tilemaps[(i + 1) % tilemaps.Length];

            // ī�޶� ���� ������� "��(-moveDir)"�� loopOffset��ŭ ����� ����!
            float distFromCam = Vector3.Dot(cur.position - mainCamera.transform.position, -moveDir);

            if (distFromCam > loopOffset.magnitude * 0.95f)
            {
                // �ٸ� Ÿ�ϸ��� "����"���� loopOffset��ŭ �̵�
                cur.position = other.position + loopOffset;
                Debug.Log($"[Loop] Move tilemap {i} to {cur.position}");
            }
        }
    }

}
