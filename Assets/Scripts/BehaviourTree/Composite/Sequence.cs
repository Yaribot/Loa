using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }
    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false;
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    //_nodeState = NodeState.RUNNING;
                    //return _nodeState;
                    isAnyNodeRunning = true;
                    break;
                //case NodeState.SUCCCESS:
                //    break;
                case NodeState.FAILURE:
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;
                default:
                    break;
            }
        }
        //_nodeState = NodeState.SUCCCESS;
        //return _nodeState;
        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCCESS; // is any child node is running ? if yes NodeState.RUNNING. if not All children node are SUCCESS so the Sequence node is a SUCCESS
        return _nodeState;
    }
}
