using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpirit : MonoBehaviour, IPooledObject
{
    private Rigidbody rb;
    //private GameObject pointsZone;
    //public List<Transform> moveSpots;

    //public Transform[] moveSpots;

    //public float speed;
    private float waitTime;
    public float startWaitTime;


    private int randomSpots;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomSpots = Random.Range(0, GameManager.Instance.npcMoveSpots.Length);
        waitTime = startWaitTime;
        //pointsZone = SpawnManager.Instance.pointsZone;
        //CheckMovePoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        OnObjectSpawned();
    }

    public void OnObjectSpawned()
    {
        // Create the behaviour of the spirit !!
        /*
        transform.LookAt(moveSpots[randomSpots].position);
        rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);

        if(Vector3.Distance(transform.position, moveSpots[randomSpots].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomSpots = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.fixedDeltaTime;
            }
        }*/

        GameManager.Instance.NpcBehaviour(rb, waitTime, startWaitTime, randomSpots);

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
