using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageStock : Interactable
{
    public GameObject inventoryUI;
    //public GameObject stockUI;
    //public GameObject pocketUI;
    //public InvPlayerController playerInteract;
    public override void Interact()
    {
        base.Interact();

        OpenInventary();
    }

    void OpenInventary()
    {
        //Debug.Log("Opening Inventary !");
       
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        //stockUI.SetActive(!stockUI.activeSelf);
        //pocketUI.SetActive(true);
      
    }

    
}
