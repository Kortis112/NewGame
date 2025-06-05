using UnityEngine;

public class PortalActivator : MonoBehaviour
{
    [Header("Деактивированный портал в сцене")]
    [SerializeField] private GameObject portalObject;      // сам портал
    [SerializeField] private PortalExit portalExit;        // компонент, если нужно задать сцену
    [SerializeField] private string nextSceneName = "Fight02";

    private void OnEnable() => EnemyManager.OnRoomCleared += ActivatePortal;
    private void OnDisable() => EnemyManager.OnRoomCleared -= ActivatePortal;

    private void Start()
    {
        if (portalObject != null) portalObject.SetActive(false);   // на всякий случай
    }

    private void ActivatePortal()
    {
        if (portalExit != null)          // задаём цель, если нужно
            portalExit.Init(nextSceneName);

        if (portalObject != null)
            portalObject.SetActive(true);
    }
}
