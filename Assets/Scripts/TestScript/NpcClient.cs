using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcClient : MonoBehaviour
{
    private IntVariable nbClient;
    // Start is called before the first frame update
    void Start()
    {
        nbClient.Value += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        nbClient.Value -= 1;
    }
}
