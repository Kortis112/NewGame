using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rogue-Like/Node Graph")]
public class NodeGraph : ScriptableObject
{
    public List<Node> chain = new();       // упорядоченный список нод
}

[Serializable]
public class Node
{
    public string scene;                   // имя сцены этой комнаты
    public NodeType type;                  // бой / магазин / босс
    public List<int> next = new();         // индексы следующих нод (1-2 шт.)
}

public enum NodeType { Fight, Shop, Boss }
