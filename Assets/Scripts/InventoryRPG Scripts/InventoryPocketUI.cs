using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPocketUI : MonoBehaviour
{
    public Transform pocketItemsParent;

    InventoryPocket inventory;

    InventorySlot[] pocketslots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = InventoryPocket.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        pocketslots = pocketItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        //Debug.Log("UPDATING UI");

        for ( int i = 0; i < pocketslots.Length; i++)
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
}
