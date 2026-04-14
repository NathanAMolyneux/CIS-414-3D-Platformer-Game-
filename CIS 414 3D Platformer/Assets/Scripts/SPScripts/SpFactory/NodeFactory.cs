using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NodeFactory : MonoBehaviour
{
    public BaseNode CreateNode(NodeType nodeType, GameObject nodeObject)
    {
        switch (nodeType)
        {
            case NodeType.Power:
                return nodeObject.AddComponent<PowerNode>();

            case NodeType.Faulty:
                return nodeObject.AddComponent<FaultyNode>();

            default:
                Debug.LogWarning("Unknown node type");
                return null;
        }
    }
}