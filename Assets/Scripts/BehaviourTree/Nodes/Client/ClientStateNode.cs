using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientStateNode : Node
{
    private bool clientOnly;
    private IntVariable nbClient;
    private float agentSpeed;
    private SpiritAI ai;

    public ClientStateNode(bool clientOnly, IntVariable nbClient, float agentSpeed, SpiritAI ai)
    {
        this.clientOnly = clientOnly;
        this.nbClient = nbClient;
        this.agentSpeed = agentSpeed;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        //spawnM = SpawnManager.Instance;
        bool rdmBool = ai.GetRandomBool();

        if (clientOnly || rdmBool)
        {
            nbClient.Value += 1;
            agentSpeed = 4f;
            ai.SetAgentSpeed(agentSpeed);
            return NodeState.SUCCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
