using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStateNode : Node
{
    private SpawnManager spawnM;

    public RandomStateNode(SpawnManager spawnM)
    {
        this.spawnM = spawnM;
    }

    public override NodeState Evaluate()
    {
        if (!spawnM.thiefOnly && !spawnM.clientOnly)
        {
            return NodeState.SUCCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
