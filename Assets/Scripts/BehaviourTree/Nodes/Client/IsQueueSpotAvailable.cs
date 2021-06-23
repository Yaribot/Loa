using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsQueueSpotAvailable : Node
{
    private QueueSpot[] availableQueue; // might delete the array and make it a single variable since ther is only one Queue
    private Transform target;
    private SpiritAI ai;

    public IsQueueSpotAvailable(QueueSpot[] availableQueue,Transform target, SpiritAI ai)
    {
        this.availableQueue = availableQueue;
        this.target = target;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform spot = FindQueueSpot();

        ai.SetBestSpot(spot);

        if (spot != null)
        {
            return NodeState.SUCCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }

    private Transform FindQueueSpot()
    {
        Transform spot = null;

        for (int i = 0; i < availableQueue.Length; i++)
        {
            if (availableQueue[i].isOccupied == true)
            {

                continue;
            }
            Transform bestSpot = FindBestQueueSpot(availableQueue[i]);

            if(bestSpot != null)
            {
                spot = bestSpot;
            }
        }

        return spot;
    }

    private Transform FindBestQueueSpot(QueueSpot queueSpot)
    {
        Transform[] availableSpots = queueSpot.GetQueueSpots();
        Transform spot = null;

        for (int i = 0; i < availableSpots.Length; i++)
        {
            //Debug.Log(availableSpots[i]);
            //if (queueSpot.isOccupied == false)
            //{
            spot = availableSpots[i];
             //   continue;
            //}
        }

        return spot;
    }


    /*private bool CheckSpotIsValid(Transform spot)
    {
        RaycastHit hit;
        Vector3 direction = target.position - spot.position;

        if (Physics.Raycast(spot.position, direction, out hit))
        {
            if (hit.collider.transform != target)
            {
                return true;
            }
        }
        return false;
    }*/

}
