using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcThief : MonoBehaviour
{
    private IntVariable nbThief;
    // Start is called before the first frame update
    void Start()
    {
        nbThief.Value += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        nbThief.Value -= 1;
    }
}
