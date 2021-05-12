using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpot : MonoBehaviour
{
    [SerializeField]
    private Transform[] lootSpots;

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
        return lootSpots;
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
