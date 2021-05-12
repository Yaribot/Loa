using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLootSpotAvailable : Node
{
    private LootSpot[] availableLoot; 
    private Transform target;
    private SpiritAI ai;

    public IsLootSpotAvailable(LootSpot[] availableLoot, Transform target, SpiritAI ai)
    {
        this.availableLoot = availableLoot;
        this.target = target;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform spot = FindLootSpot();

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

    private Transform FindLootSpot()
    {
        Transform spot = null;

        for (int i = 0; i < availableLoot.Length; i++)
        {
            if (availableLoot[i].isOccupied == true)
            {
                continue;                               // "continue" allow you to skip itterration of the loop in regaard to the condition
            }
            //Debug.Log(availableLoot[i]);
            Transform bestSpot = FindBestLootSpot(availableLoot[i]);
            if (bestSpot != null)
            {
                spot = bestSpot;
            }
        }

        return spot;
    }

    private Transform FindBestLootSpot(LootSpot lootSpot)
    {
        Transform[] availableSpots = lootSpot.GetQueueSpots();
        Transform spot = null;
        
        for (int i = 0; i < availableSpots.Length; i++)
        {
            //Debug.Log(availableSpots[i]);

            //if (lootSpot.isOccupied == false)
            //{
            spot = availableSpots[i];
            //    continue;
            //}

            /* if (CheckSpotIsValid(availableSpots[i]))     // to reset thing to how it was before just uncomment this part
             {              
                 spot = availableSpots[i];
             }*/
        }
        //Debug.Log(spot.position);
        return spot;
    }

    private bool CheckSpotIsValid(Transform spot)
    {
        // What i want  = if a spot is empty, the spot is valid. If the spot is occupied by a Spirit, the spot is not valid  and the spirit look for another spot

        //what is happening = the spirit find a spot, and if the player come too close the spot is invalid and the spirit look for another one

        // 1# SOLUTION = loop through all enemies and check disitance between the spot and the enemy
        // 2# SOLUTION = use sphere collider to detect if an enemy has passed through sphere <--- trying this
            // need to check if the bool of a spot is true or not. Maybe somthing like this, but the GetComponent can be problematic

            // lootSpot = availableSpots[i].GetComponent<QueueSpot>();
            /*if (lootSpot)
            {
                spot is valid
            }*/



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
    }
}
