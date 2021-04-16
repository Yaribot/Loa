using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    public override void Init()
    {
        base.Init();
        Debug.Log("AudioManager initialized");
    }
}
