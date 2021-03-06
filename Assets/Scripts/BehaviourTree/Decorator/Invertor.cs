using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertor : Node
{
    protected Node node;

    public Invertor(Node node)
    {
        this.node = node;
    }
    public override NodeState Evaluate()
    {
       
        switch (node.Evaluate())
        {
            case NodeState.RUNNING:
                _nodeState = NodeState.RUNNING;
                break;
            case NodeState.SUCCCESS:
                _nodeState = NodeState.FAILURE;
                break;
            case NodeState.FAILURE:
                _nodeState = NodeState.SUCCCESS;
                break;
            default:
                break;
        }
        return _nodeState;
    }
}
