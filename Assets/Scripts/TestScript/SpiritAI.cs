using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiritAI : MonoBehaviour, INpcInteractable
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
    Transform player;
    private NavMeshAgent agent;
    private Node topNode;
    private Repeator repeatMovingToSpot;
    private Coroutine behavior;

    private bool rdmBool;
    public bool isOrdering;
    public bool isInPosition;
    public bool isAClient;
    public bool onlyOnce;
    private bool startBehaviour;
    bool isFocused = false;
    bool hasInteracted = false;

    private float myTime;

    private Node mRoot;
    public Node Root { get { return mRoot; } }

    private float radius;
    float INpcInteractable.Radius
    {
        get
        {
            return radius;
        }
        set
        {
            radius = 3f;
        }
    }

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
        //isOrdering = false;
        startBehaviour = false;
        isInPosition = false;
        onlyOnce = false;

        myTime = 0f;

        //mRoot = new Node(this);

        //if (topNode.nodeState == NodeState.FAILURE)
        //{
        //    SetColor(Color.white);
        //}
    }
    
    private void ConstructBehaviourTree()
    {
        OrderGenerator orderGenerator = new OrderGenerator(gameM.stockItems, gameM.nbItemsOrdered, this);
        ArriveAtPosition arriveAtPosition = new ArriveAtPosition(this);
        IsQueueSpotAvailable queueSpotAvailable = new IsQueueSpotAvailable(spawnM.availableQueue, gameM.playerTransform, this);
        GoToQueueSpot goToQueueSpot = new GoToQueueSpot(agent, this);
        IsLootSpotAvailable lootSpotAvailable = new IsLootSpotAvailable(spawnM.availableLoot, gameM.playerTransform, this);
        GoToLootSpot goToLootSpot = new GoToLootSpot(agent, this);
        RandomStateNode randomStateNode = new RandomStateNode(spawnM);
        ClientStateNode clientStateNode = new ClientStateNode(spawnM.clientOnly, gameM.nbClient, agent.speed, this);
        ThiefStateNode thiefStateNode = new ThiefStateNode(spawnM.thiefOnly, gameM.nbThief, agent.speed, this);
        FindState findState = new FindState(this);



        Sequence orderSequence = new Sequence(new List<Node> { orderGenerator });

        //Sequence goingToCounter = new Sequence(new List<Node> { goToQueueSpot, goToPosition);
        //Selector goToposition = new Selector(new List<Node> { orderSequence, goingToCounter });
        repeatMovingToSpot = new Repeator(goToQueueSpot);
        Sequence goToQueueSpotSequence = new Sequence (new List<Node> { queueSpotAvailable, repeatMovingToSpot, orderSequence });
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
        DistanceBetweenSpots();
        //Debug.Log(isInPosition);
        //------------------------
        /*topNode.Evaluate();

        if(topNode.nodeState == NodeState.FAILURE) Putting TopNode in Evaluate will make the NPC chage State Randomly
        {
            SetColor(Color.white);
        }*/
        //------------------------

        //Debug.Log(rdmBool);
        //Debug.Log(mat.color);
        //Debug.Log(isAClient);
        myTime += Time.deltaTime;
        if (!isInPosition && isAClient)
        {
            if (myTime >= 5f)
            {
                CheckIfRepeatRunning(repeatMovingToSpot);
                myTime = 0f;
            }
        }
        //}else if(isInPosition && isAClient)
        //{
        //    if (!onlyOnce)
        //    {
        //        CheckIfRepeatRunning(repeatMovingToSpot);
        //        onlyOnce = true;
        //    }
        //}

    }

    private void CheckIfRepeatRunning(Repeator repeat)
    {
        if (repeat.Evaluate() != Node.NodeState.RUNNING)
        {
            isInPosition = true;
        }
        else
        {
            isInPosition = false;
            behavior = StartCoroutine(RunBehavior(repeat));
            startBehaviour = true;
        }
    }

    private IEnumerator RunBehavior(Repeator repeat)
    {
        Node.NodeState result = repeat.Evaluate();
        while (result == Node.NodeState.RUNNING)
        {
            Debug.Log(repeat.ToString() + " result: " + result);
            yield return new WaitForSeconds(5f);
            result = repeat.Evaluate();
        }
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

    public float DistanceBetweenSpots()
    {
        float distance = Vector3.Distance(spot.position, agent.transform.position);
        //Debug.Log(isInPosition);
        if (distance > 2f)
        {
            isInPosition = false;
        }
        else if (distance <= 2f)
        {
            //Debug.Log("IN POSITION");
            isInPosition = true;
        }
        return distance;
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

    public void NpcInteractable()
    {
        Debug.Log("INTERACTING WITH " + transform.name);
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OndeFocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
