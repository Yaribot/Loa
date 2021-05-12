using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToLootSpot : Node
{
    private NavMeshAgent agent;
    private SpiritAI ai;

    public GoToLootSpot(NavMeshAgent agent, SpiritAI ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform lootSpot = ai.GetQueueSpot();

        if (lootSpot == null)
        {
            return NodeState.FAILURE;
        }

        float distance = Vector3.Distance(lootSpot.position, agent.transform.position);

        if (distance > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(lootSpot.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCCESS;
        }
    }
}
