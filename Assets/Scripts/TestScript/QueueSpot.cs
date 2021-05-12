using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueSpot : MonoBehaviour
{
    [SerializeField]
    private Transform[] queueSpots;

    public bool isOccupied;

    private void Start()
    {
        isOccupied = false;   
    }

    private void Update()
    {
        
    }

    public Transform[] GetQueueSpots()
    {
        return queueSpots;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpiritTag"))
        {
            isOccupied = true;
        }       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SpiritTag"))
        {
            isOccupied = false;
        }
    }
}
