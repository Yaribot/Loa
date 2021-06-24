using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node 
{
    public bool starting = true;
    public int ticks = 0;
    protected NodeState _nodeState;
    public NodeState nodeState { get { return _nodeState; } }


    public abstract NodeState Evaluate();

    public void Reset()
    {
        starting = true;
        ticks = 0;
    }
    public enum NodeState
    {
        RUNNING, SUCCCESS, FAILURE,
    }
}

