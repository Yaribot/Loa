using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionnary;


    public override void Init()
    {
        base.Init();
        Debug.Log("SpawnManager Initialized");
    }

    private void Start()
    {
        poolDictionnary = new Dictionary<string, Queue<GameObject>>();
        CheckPools();
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
}
