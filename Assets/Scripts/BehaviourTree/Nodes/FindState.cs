using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindState : Node
{
    
    private SpiritAI ai;


    //private Node[] nodes;

    public FindState(SpiritAI ai)
    {
        this.ai = ai;
    }


    public override NodeState Evaluate()
    {
        //Node node = FindNode();
        bool rdmState = FindNode();
        //Debug.Log(rdmState);
        ai.SetRandomBool(rdmState);

        if (rdmState || !rdmState)
        {
            return NodeState.SUCCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }

    }

    private bool FindNode()
    {
        // When you declare a local variable like "bool myBool;" it's declared but not initialized so if you put a condition after that variable 
        // And you want myBool in return it may return a error due to the compiler thinking that the value might not be asssignated, to resolve it  
        // You have to either put a value after you declare your variable or put an "else" clause following your condition

        bool rdmBool ;
        

        rdmBool = UnityEngine.Random.value > 0.5f; 
            

        //Debug.Log(runOnce);
        return rdmBool;
    }
}
