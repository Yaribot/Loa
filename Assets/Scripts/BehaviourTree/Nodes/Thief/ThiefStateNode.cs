using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefStateNode : Node
{
    private bool thiefOnly;
    private IntVariable nbThief;
    private float agentSpeed;
    private SpiritAI ai;

    public ThiefStateNode(bool thiefOnly, IntVariable nbThief, float agentSpeed, SpiritAI ai)
    {
        this.thiefOnly = thiefOnly;
        this.nbThief = nbThief;
        this.agentSpeed = agentSpeed;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        //spawnM = SpawnManager.Instance;
        bool rdmBool = ai.GetRandomBool();

        if (thiefOnly || !rdmBool)
        {
            nbThief.Value += 1;
            agentSpeed = 5f; 
            ai.SetAgentSpeed(agentSpeed);
            //Debug.Log(agentSpeed);
            ai.SetColor(Color.red);
            return NodeState.SUCCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
