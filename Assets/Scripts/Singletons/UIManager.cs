using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject pocketUI;

    public Transform pocketItemsParent;

    InventoryPocket inventory;

    InventorySlot[] pocketslots;

    /* private static UIManager _instance;
     public static UIManager Instance
     {
         get
         {
             if(_instance == null)
             {
                 Debug.LogError("UImanager is null");

                 //LAZY INSTANTIATION
                 GameObject go = new GameObject("UI Manager");  // if the instance is null we create the object with it's componnent wich is the script UIManager
                 go.AddComponent<UIManager>();
                // DROWBACK ---> if you have to ref a prefab to the script you'll have to do that dynamically through code
             }

             return _instance;
         }
     }

     private void Awake()
     {
         _instance = this;
     }*/

    public override void Init()
    {
        base.Init();

        Debug.Log("UIManager initialized");
    }

    void Start()
    {
        inventory = InventoryPocket.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        pocketslots = pocketItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        //Debug.Log("UPDATING UI");

        for (int i = 0; i < pocketslots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                pocketslots[i].AddItem(inventory.items[i]);
            }
            else
            {
                pocketslots[i].ClearSlot();
            }
        }
    }

    public void UpdateScore(int score)
    {
        Debug.Log("Scores " + score);
        Debug.Log("Notifying the game manager");
        GameManager.Instance.DisplayName();
    }


    public void UpdateItems(int items)
    {

    }

    public void OpenClosePocket()
    {


        pocketUI.SetActive(!pocketUI.activeSelf);
        

    }
}