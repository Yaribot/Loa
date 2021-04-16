using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    public override void Init()
    {
        base.Init();
        Debug.Log("SpawnManager Initialized");
    }

    public void Spawning()
    {
        Debug.Log("Start Spwaning !!");
    }
}
