using Game.Systems;
using UnityEngine;

/// <summary>Создаёт граф комнат перед стартом забега.</summary>
public class GraphGenerator : MonoBehaviour
{
    [Header("Пулы сцен")]
    [SerializeField] private string[] fightScenes = { "Fight01", "Fight02" };
    [SerializeField] private string shopScene = "Shop";
    [SerializeField] private string bossScene = "Boss";

    private void Awake()
    {
        var g = ScriptableObject.CreateInstance<NodeGraph>();

        // 1-я нода — бой
        g.chain.Add(new Node
        {
            scene = fightScenes[Random.Range(0, fightScenes.Length)],
            type = NodeType.Fight
        });

        // 2-я нода  (Fight или Shop)
        bool shopHere = Random.value > 0.5f;
        g.chain.Add(new Node
        {
            scene = shopHere ? shopScene
                                                : fightScenes[Random.Range(0, fightScenes.Length)],
            type = shopHere ? NodeType.Shop : NodeType.Fight
        });

        // 3-я нода — бой
        g.chain.Add(new Node
        {
            scene = fightScenes[Random.Range(0, fightScenes.Length)],
            type = NodeType.Fight
        });

        // 4-я нода — босс, финал
        g.chain.Add(new Node { scene = bossScene, type = NodeType.Boss });

        // связи (0)→1,2  ; (1)→2  ; (2)→3
        g.chain[0].next.AddRange(new[] { 1, 2 });
        g.chain[1].next.Add(2);
        g.chain[2].next.Add(3);

        RunData.graph = g;
        RunData.currentNode = 0;
        RunData.goldRun = 0;
    }
}
