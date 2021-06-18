using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToQueueSpot : Node
{
    private NavMeshAgent agent;
    private SpiritAI ai;

    public GoToQueueSpot(NavMeshAgent agent, SpiritAI ai)
    {
        this.agent = agent;
        this.ai = ai;
    }


    public override NodeState Evaluate()
    {
        Transform queueSpot = ai.GetQueueSpot();

        if (queueSpot == null)
        {
            return NodeState.FAILURE;
        }

        float distance = Vector3.Distance(queueSpot.position, agent.transform.position);

        if (distance > 0.2f)
        {
            //ai.isInPosition = false;
            agent.isStopped = false;
            agent.SetDestination(queueSpot.position);
            return NodeState.RUNNING;           
        }
        else
        {
            //ai.isInPosition = true;
            agent.isStopped = true;
            return NodeState.SUCCCESS;
        }
    }
}
