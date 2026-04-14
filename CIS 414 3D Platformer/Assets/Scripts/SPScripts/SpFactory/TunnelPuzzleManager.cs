using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TunnelPuzzleManager : MonoBehaviour
{
    [SerializeField] private NodeFactory nodeFactory;

    [SerializeField] private GameObject node1;
    [SerializeField] private GameObject node2;
    [SerializeField] private GameObject node3;

    private void Start()
    {
        if (nodeFactory == null)
        {
            Debug.LogWarning("NodeFactory is missing.");
            return;
        }

        nodeFactory.CreateNode(NodeType.Power, node1);
        nodeFactory.CreateNode(NodeType.Faulty, node2);
        nodeFactory.CreateNode(NodeType.Power, node3);

        Debug.Log("Tunnel puzzle nodes created by Factory.");
    }
}