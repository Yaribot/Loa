using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiritAI : MonoBehaviour
{
    /*[SerializeField]
    private QueueSpot[] availableQueue;
    [SerializeField]
    private QueueSpot[] availableLoot;*/
    /*[SerializeField]
    private Transform playerTransform;*/
    /*[SerializeField]
    private Node[] nodes;*/

    private SpawnManager spawnM;
    private GameManager gameM;


    private Material mat;
    private Transform spot;
    private NavMeshAgent agent;
    private Node topNode;

    private bool rdmBool;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        spawnM = SpawnManager.Instance;
        gameM = GameManager.Instance;
        mat = GetComponentInChildren<MeshRenderer>().material;
        ConstructBehaviourTree();
        topNode.Evaluate();

        if (topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.white);
        }

    }
    
    private void ConstructBehaviourTree()
    {
        OrderGenerator orderGenerator = new OrderGenerator(gameM.stockItems, gameM.nbItemsOrdered, this);
        IsQueueSpotAvailable queueSpotAvailable = new IsQueueSpotAvailable(spawnM.availableQueue, gameM.playerTransform, this);
        GoToQueueSpot goToQueueSpot = new GoToQueueSpot(agent, this);
        IsLootSpotAvailable lootSpotAvailable = new IsLootSpotAvailable(spawnM.availableLoot, gameM.playerTransform, this);
        GoToLootSpot goToLootSpot = new GoToLootSpot(agent, this);
        RandomStateNode randomStateNode = new RandomStateNode(spawnM);
        ClientStateNode clientStateNode = new ClientStateNode(spawnM.clientOnly, gameM.nbClient, agent.speed, this);
        ThiefStateNode thiefStateNode = new ThiefStateNode(spawnM.thiefOnly, gameM.nbThief, agent.speed, this);
        FindState findState = new FindState(this);



        Sequence orderSequence = new Sequence(new List<Node> { orderGenerator });
        Sequence goToQueueSpotSequence = new Sequence (new List<Node> { queueSpotAvailable, goToQueueSpot, orderSequence });
        Sequence goToLootSpotSequence = new Sequence (new List<Node> { lootSpotAvailable, goToLootSpot });

        Sequence thiefSequence = new Sequence(new List<Node> { thiefStateNode, goToLootSpotSequence });
        Sequence clientSequence = new Sequence(new List<Node> { clientStateNode, goToQueueSpotSequence });

        Selector GoToStateSelector = new Selector(new List<Node> { clientSequence, thiefSequence });
        Sequence randomBoolSequence = new Sequence(new List<Node> { findState, GoToStateSelector });
        Sequence randomSequence = new Sequence(new List<Node> { randomBoolSequence, randomStateNode });

        topNode = new Selector(new List<Node> { randomSequence, clientSequence, thiefSequence });

        //Debug.Log(findState.Evaluate());
        //Debug.Log(clientSequence.Evaluate());
        //Debug.Log(randomBoolSequence.Evaluate());
    }


    // Update is called once per frame
    void Update()
    {
        //------------------------
        /*topNode.Evaluate();

        if(topNode.nodeState == NodeState.FAILURE) Putting TopNode in Evaluate will make the NPC chage State Randomly
        {
            SetColor(Color.white);
        }*/
        //------------------------

        //Debug.Log(rdmBool);
        //Debug.Log(mat.color);
    }

    internal void SetColor(Color color)
    {
        mat.color = color;
    }

    public void SetBestSpot(Transform spot)
    {
        this.spot = spot;
    }

    public Transform GetQueueSpot()
    {
        return spot;
    }

    public void SetRandomBool(bool rdmBool)
    {
        this.rdmBool = rdmBool;
    }

    public bool GetRandomBool()
    {
        return rdmBool;
    }

    public void SetAgentSpeed(float agentSpeed)
    {
        this.agent.speed = agentSpeed;
    }
}
