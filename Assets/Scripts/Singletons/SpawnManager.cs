using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionnary;

    public bool isSpawningClientThief;
    public bool clientOnly;
    public bool thiefOnly;

    private IntVariable nbClient;
    private IntVariable nbThief;


    public override void Init()
    {
        base.Init();
        Debug.Log("SpawnManager Initialized");
    }

    private void Start()
    {
        poolDictionnary = new Dictionary<string, Queue<GameObject>>();
        CheckPools();
        //isSpawningClientThief = true;
    }

    private void Update()
    {
        CheckNbClientThief();
    }

    public void Spawning()
    {
        Debug.Log("Start Spwaning !!");
    }

    private void CheckPools()
    {
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectsPool = new Queue<GameObject>();

            for(int i= 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectsPool.Enqueue(obj);
            }

            poolDictionnary.Add(pool.tag, objectsPool);
        } 
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionnary.ContainsKey(tag))
        {
            Debug.LogWarning("The Pool with tag " + tag + " doesn't exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionnary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        /*if(pooledObj != null)
        {
            pooledObj.OnObjectSpawned();
        }*/

        poolDictionnary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public void CheckNbClientThief()
    {
        if (nbClient.Value <= 4 || nbThief.Value <= 5)
        {
            isSpawningClientThief = true;
        }
        else if(nbClient.Value == 4 && nbThief.Value == 5)
        {
            isSpawningClientThief = false;
        }

        if (nbClient.Value <= 3 && nbThief.Value <= 4)
        {
            clientOnly = false;
            thiefOnly = false;
        }

        if (nbClient.Value >= 4)
        {
            thiefOnly = true;
            clientOnly = false;
        }

        if (nbThief.Value >= 5)
        {
            clientOnly = true;
            thiefOnly = false;
        }
    }
}
