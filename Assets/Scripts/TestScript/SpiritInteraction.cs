using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiritInteraction : Interactable
{
    private SpiritAI ai;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<SpiritAI>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public override void Interact()
    //{
    //    base.Interact();
    //    if (agent.isStopped)
    //    {
    //        GinveItemsUI();
    //    }
    //}
    
    private void GinveItemsUI()
    {
        //create a UI Button to give Items in the player pocket
        Debug.Log("Giving the items stored in the player's pocket");
    }
}
