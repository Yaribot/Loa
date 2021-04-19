using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritVision : MonoBehaviour
{
    public GameObject spirit;
    private Renderer spiritRend;
    private Shader spiritShader;

    private float invisible = 1;
    private float visible = 0;
    private float smoothSpeed = 35f;
    private float lerp;
    private float myTime;
    private float fadeDuration = 5f;

    private int gradiantID;

    public bool isApearing;
    public bool isDisapearing;

    // Start is called before the first frame update
    void Start()
    {
        spiritRend = spirit.GetComponentInChildren<Renderer>();
        //spiritShader = spirit.GetComponent<Shader>();
        gradiantID = spiritRend.material.GetInt("Transparancy");
        lerp = invisible;
        myTime = 0f;
        isApearing = false;
        isDisapearing = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpiritTag"))
        {
            Debug.Log("SPIRIT ENTER");
            CheckBool();
            myTime = 0f;

            if (isApearing)
            {
                myTime += Time.deltaTime;

                FadingFunction(lerp, visible);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SpiritTag"))
        {
            Debug.Log("SPIRIT EXIT");
            CheckBool();
            myTime = 0f;

            if (isDisapearing)
            {
                myTime += Time.deltaTime;
                FadingFunction(lerp, invisible);
            }
        }

    }

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

            spiritRend.material.SetFloat(gradiantID, lerp);

        }
        else
        {
            Debug.Log("FADE");
            lerp = param2;
        }
    }
}
