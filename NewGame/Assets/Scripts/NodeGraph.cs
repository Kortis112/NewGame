using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rogue-Like/Node Graph")]
public class NodeGraph : ScriptableObject
{
    public List<Node> chain = new();       // ������������� ������ ���
}

[Serializable]
public class Node
{
    public string scene;                   // ��� ����� ���� �������
    public NodeType type;                  // ��� / ������� / ����
    public List<int> next = new();         // ������� ��������� ��� (1-2 ��.)
}

public enum NodeType { Fight, Shop, Boss }
