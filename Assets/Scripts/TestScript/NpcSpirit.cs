using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpirit : MonoBehaviour, IPooledObject
{
    private Rigidbody rb;
    //private GameObject pointsZone;
    //public List<Transform> moveSpots;

    private Transform[] moveSpots;

    private float speed;
    private float waitTime;
    public float startWaitTime;


    private int randomSpots;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpots = GameManager.Instance.npcMoveSpots;
        randomSpots = Random.Range(0, moveSpots.Length);
        speed = GameManager.Instance.npcSpeed;
        waitTime = startWaitTime;
        //pointsZone = SpawnManager.Instance.pointsZone;
        //CheckMovePoints();

    }

    // Update is called once per frame
    void Update()
    {
        RecalculateDirection();
    }

    private void FixedUpdate()
    {
        OnObjectSpawned();
        //Debug.Log(moveSpots[randomSpots].position);
    }

    public void OnObjectSpawned()
    {
        // Create the behaviour of the spirit !!
        
        transform.LookAt(moveSpots[randomSpots].position);
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);

        

       // GameManager.Instance.NpcBehaviour(rb, waitTime, startWaitTime, randomSpots);

    }

    public void RecalculateDirection()
    {
        if (Vector3.Distance(transform.position, moveSpots[randomSpots].position) < 20f)
        {
            if (waitTime <= 0)
            {
                randomSpots = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    /*private void CheckMovePoints()
    {
        foreach (Transform child in pointsZone.transform)
        {
            moveSpots.Add(child);
        }
    }
    */

     /*public void FollowWithRotation()
    {
        transform.LookAt(moveSpots[randomSpots]);
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
    }*/
}
