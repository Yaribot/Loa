using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClientThief : MonoBehaviour
{
    SpawnManager spawnManager;

    private float spawnerTime;
    public float spawnDelay;

    private bool isSpawning;

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

        if (spawnManager.isSpawningClientThief)
        {
            Spawning();
        }
    }

    public void Spawning()
    {
        if (spawnerTime > spawnDelay)
        {
            spawnerTime = 0f;
            spawnManager.SpawnFromPool("ClientThief", transform.position, transform.rotation);
        }
    }

}
