using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    
    public Transform[] npcMoveSpots;
    public float npcSpeed;
  
    public override void Init()
    {
        base.Init();
        Debug.Log("GameManager initialized");
    }

    private void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
    }

    public void DisplayName()
    {
        Debug.Log("My name is Yannis");
    }

    public void NpcBehaviour(Rigidbody rb, float waitTime, float startTime, int randomSpots)
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        rb.transform.LookAt(npcMoveSpots[randomSpots].position);
        rb.AddRelativeForce(Vector3.forward * npcSpeed, ForceMode.Force);

        if (Vector3.Distance(rb.transform.position, npcMoveSpots[randomSpots].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpots = Random.Range(0, npcMoveSpots.Length);
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.fixedDeltaTime;
            }
        }
    }
}
