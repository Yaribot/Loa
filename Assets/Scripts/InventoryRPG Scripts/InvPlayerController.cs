using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvPlayerController : MonoBehaviour
{
   

    private bool interact;
    private bool invPocket;
    public bool isInteracting;


    

    public Interactable focus;
    public GameObject inventoryUI;
    //public GameObject pocketUI;

    //public InventorySlot slot;

    
    // Start is called before the first frame update
    void Start()
    {
        
        isInteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        InteractFunc();
        ShowPocket();
    }
  
    private void GetInput()
    {    
        interact = Input.GetKeyDown(KeyCode.C);
        invPocket = Input.GetKeyDown(KeyCode.E);
    }

    
    private void InteractFunc()
    {
        if (interact)
        {
            Vector3 dir = transform.TransformDirection(Vector3.forward) * 2f;
            Debug.DrawRay(transform.position + transform.up * 0.3f, dir, Color.green, 2f);
            if (!isInteracting)
            {
                //Debug.Log("INTERACTING WITH AN OBJECT !!");
                RaycastHit hit;


                if(Physics.Raycast(transform.position + transform.up * 0.3f, transform.TransformDirection(Vector3.forward), out hit, 2f))
                {                   
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if(interactable != null)
                    {
                        SetFocus(interactable);
                        isInteracting = true;
                    }
                }
            }
            else
            {
                RemoveFocus();
                CloseInventory();
                isInteracting = false;
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        focus.OndeFocused();
        focus = null;
    }

    void CloseInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    /*private void OnDrawGizmos()
    {
        if (interact)
        {
            
            Vector3 dir = transform.TransformDirection(Vector3.forward) * 10f;
            Debug.DrawRay(transform.position, dir, Color.green);
        }
    }*/

    void ShowPocket()
    {
        if (invPocket)
        {
            UIManager.Instance.OpenClosePocket();
        }
    }
}
