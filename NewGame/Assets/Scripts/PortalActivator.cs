using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    [Header("���������������� ������ � �����")]
    [SerializeField] private GameObject portalObject;      // ��� ������
    [SerializeField] private PortalExit portalExit;        // ���������, ���� ����� ������ �����
    [SerializeField] private string nextSceneName = "Fight02";

    private void OnEnable() => EnemyManager.OnRoomCleared += ActivatePortal;
    private void OnDisable() => EnemyManager.OnRoomCleared -= ActivatePortal;

    private void Start()
    {
        if (portalObject != null) portalObject.SetActive(false);   // �� ������ ������
    }

    private void ActivatePortal()
    {
        if (portalExit != null)          // ����� ����, ���� �����
            portalExit.Init(nextSceneName);

        if (portalObject != null)
            portalObject.SetActive(true);
    }
}
