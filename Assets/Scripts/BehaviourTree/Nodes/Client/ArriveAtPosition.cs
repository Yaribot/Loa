using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArriveAtPosition : Node
{
    private SpiritAI ai;

    public ArriveAtPosition(SpiritAI ai)
    {
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (ai.isInPosition)
        {
            return NodeState.SUCCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
