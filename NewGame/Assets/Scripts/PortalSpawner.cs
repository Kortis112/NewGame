using Game.Systems;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] private PortalExit portalPrefab;
    [SerializeField] private float xSpread = 3f;     // пол-ширина распределения
    [SerializeField] private float yOffset = -1f;    // чуть ниже центра комнаты

    private void OnEnable() => EnemyManager.OnRoomCleared += SpawnPortals;
    private void OnDisable() => EnemyManager.OnRoomCleared -= SpawnPortals;

    private void SpawnPortals()
    {
        var graph = RunData.graph;
        var current = RunData.currentNode;
        var nextIds = graph.chain[current].next;     // 1…3 путей

        int count = nextIds.Count;
        float step = (count == 1) ? 0
                    : (count == 2) ? xSpread
                    : xSpread * 2;                   // = 3 портала

        for (int i = 0; i < count; i++)
        {
            // равномерно распределяем по оси X: (-step, 0, +step)
            float xPos = (count == 1) ? 0
                       : (i == 0) ? -step
                       : (i == 1 && count == 2) ? step
                       : 0;                       // i==1 при 3-порталах = центр

            if (count == 3) xPos = (i - 1) * step; // -step,0,+step

            Vector3 pos = new Vector3(xPos, yOffset, 0) + transform.position;
            var portal = Instantiate(portalPrefab, pos, Quaternion.identity);
            //portal.Init(nextIds[i], graph.chain[nextIds[i]].type);
        }
    }
}
