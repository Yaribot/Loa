using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeator : Node
{
    protected Node node;

    public Repeator(Node node)
    {
        this.node = node;
    }

    public override NodeState Evaluate()
    {
        if (node.Evaluate() != NodeState.RUNNING)
        {
            _nodeState = node.Evaluate();
            return _nodeState;
            //Reset();
            //node.Reset();
        }
        else
        {
            _nodeState = NodeState.RUNNING;
            return _nodeState;
        }
        //throw new System.NotImplementedException();
    }
}
