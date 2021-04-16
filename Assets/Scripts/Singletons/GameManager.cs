using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public override void Init()
    {
        base.Init();
        Debug.Log("GameManager initialized");
    }

    public void DisplayName()
    {
        Debug.Log("My name is Yannis");
    }
}
