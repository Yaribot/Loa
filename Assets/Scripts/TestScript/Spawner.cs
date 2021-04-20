using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    SpawnManager spawnManager;

    private float spawnerTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = SpawnManager.Instance;
        spawnerTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        spawnerTime += Time.fixedDeltaTime;

        if(spawnerTime > spawnDelay)
        {
            spawnerTime = 0f;
            spawnManager.SpawnFromPool("PassingBy", transform.position, transform.rotation);
        }
    }
}
