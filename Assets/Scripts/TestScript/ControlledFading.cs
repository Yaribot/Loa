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
    
    //private bool fadeImput;
    public bool isApearing;
    public bool isDisapearing;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        gradiantID = Shader.PropertyToID("Transparancy"); // call property "Transparancy" from shader Fade & turn it to an int. Other way could have use Shader.Find (cost more)
        rend.material.SetFloat(gradiantID, invisible);
        lerp = invisible;
        myTime = 0f;
        isApearing = false;
        isDisapearing = false;

    }

    // Update is called once per frame
    void Update()
    {/*
        GetInput();

        if (fadeImput)
        {
            CheckBool();
            myTime = 0f;
        }
        */

       
        if (isApearing)
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
        //Debug.Log(myTime);
    }

    /*public void GetInput()
    {
        fadeImput = Input.GetKeyDown(KeyCode.F);
    }*/

    public void CheckBool()
    {
        //Debug.Log("CHECKING");
        if (!isApearing)
        {
            isApearing = true;
            isDisapearing = false;
            return;
        }
        if (!isDisapearing)
        {
            isDisapearing = true;
            isApearing = false;
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
            //Debug.Log("FADE");
            lerp = param2;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("VisionTag"))
        {
            CheckBool();
            myTime = 0f;
            /*
                //Debug.Log("SPIRIT ENTER");
                CheckBool();
                myTime = 0f;

                if (isApearing)
                {
                    myTime += Time.deltaTime;

                    FadingFunction(lerp, visible);
                }
            */
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("VisionTag"))
        {
            CheckBool();
            myTime = 0f;
            /*
                //  Debug.Log("SPIRIT EXIT");
                CheckBool();
                myTime = 0f;

                if (isDisapearing)
                {
                    myTime += Time.deltaTime;
                    FadingFunction(lerp, invisible);
                }
            */
        }
    }

}
