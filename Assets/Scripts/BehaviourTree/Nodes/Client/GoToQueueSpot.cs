using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToQueueSpot : Node
{
    private NavMeshAgent agent;
    private SpiritAI ai;
    private bool isInPos;

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
            ai.isInPosition = false;
            return NodeState.FAILURE;
        }

        //float distance = Vector3.Distance(queueSpot.position, agent.transform.position);
        float distance = ai.DistanceBetweenSpots(); 
        
        if (distance > 2f)
        {
            Debug.Log("GOING TO POSITION");
            //ai.isInPosition = false;
            agent.isStopped = false;
            agent.SetDestination(queueSpot.position);
            //ticks++;
            Debug.Log(ticks);
            starting = false;
            return NodeState.RUNNING;
        }
        else // if (distance <= 0.2f)
        {
            //notInPosition = false;
            ai.isInPosition = true;
            
            Debug.Log("IN POSITION TO ORDER");
            agent.isStopped = true;
            starting = false;
            return NodeState.SUCCCESS;
        }
        //starting = false;
        
        //return NodeState.FAILURE;
    }

    //private IEnumerator IsInPosition(float waitTime)
    //{
    //    isInPos = ai.isInPosition;
    //    yield return new WaitForSeconds(waitTime);
    //}
}
