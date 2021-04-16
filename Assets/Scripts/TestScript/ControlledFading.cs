using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledFading : MonoBehaviour
{
    private float invisible = 1;
    private float visible = 0;
    private float smoothSpeed = 35f;
    public float lerp;
    private float myTime;
    private float fadeDuration = 5f;

    private int gradiantID;

    private Renderer rend;
    
    private bool fadeImput;
    public bool isFading;
    public bool isDisapearing;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        gradiantID = Shader.PropertyToID("Transparancy"); // call property "Transparancy" from shader Fade & turn it to an int. Other way could have use Shader.Find (cost more)
        rend.material.SetFloat(gradiantID, invisible);
        lerp = invisible;
        myTime = 0f;
        isFading = false;
        isDisapearing = false;

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        if (fadeImput)
        {
            CheckBool();
            myTime = 0f;
        }

       
        if (isFading)
        {
            myTime += Time.deltaTime;

            FadingFunction(lerp, visible);
        }
        if (isDisapearing)
        {
            myTime += Time.deltaTime;
            FadingFunction(lerp, invisible);
        }
        //Debug.Log(gradVal);

    }

    public void GetInput()
    {
        fadeImput = Input.GetKeyDown(KeyCode.F);
    }

    public void CheckBool()
    {
        //Debug.Log("CHECKING");
        if (!isFading)
        {
            isFading = true;
            isDisapearing = false;
            return;
        }
        if (!isDisapearing)
        {
            isDisapearing = true;
            isFading = false;
            return;
        }
    }

    public void FadingFunction(float param1, float param2)
    {
        if (myTime < fadeDuration)
        {
            lerp = Mathf.Lerp(param1, param2, myTime / smoothSpeed);

            rend.material.SetFloat(gradiantID, lerp);

        }
        else
        {
            Debug.Log("FADE");
            lerp = param2;
        }

    }

}
