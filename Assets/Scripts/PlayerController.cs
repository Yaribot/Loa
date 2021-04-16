using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float targetAngle;
    public float _speed;
    public float _speedRotation;

    private Vector3 direction;
    private Quaternion rotate;

    private Rigidbody rb;

    public Transform cam; // drag the MAIN camera to get the transform of the MAIN camera

    // Start is called before the first frame update
    void Start()
    {
        // ex : call singletons
        /*UIManager.Instance.UpdateScore(40);
        SpawnManager.Instance.Spawning();*/

        rb = GetComponent<Rigidbody>();
        


    }
    private void Update()
    {
        GetImput();
        CalculateDirection();
        
    }
    private void FixedUpdate()
    {
        Move();
        
    }

    private void GetImput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void CalculateDirection()
    {   

        direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        

    }

    private void HandleRotation()
    {
        targetAngle = cam.eulerAngles.y; // angle of cam

        rotate = Quaternion.Euler(0f, targetAngle, 0f); // rotation by the angle of cam
        
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, (rotate * direction), _speedRotation * Time.fixedDeltaTime,0f));
        
        // quaternion * vetor = rotated vector
    }

    private void Move()
    {
        if (direction.magnitude != 0.1f)
        {
            HandleRotation();
            rb.MovePosition(transform.position + (rotate * direction) * _speed * Time.deltaTime);
        }
    }


    
}
