using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPocket : MonoBehaviour
{
    #region Singleton
    public static InventoryPocket instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found !");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;
    public List<Item> items = new List<Item>();

    public int maxItems = 4;
   

    public void AddToPocket(Item item)
    {
        if (items.Count < maxItems)
        {
            items.Add(item);
            Debug.Log("An Item has been added to the pocket, there is " + items.Count + " items in the pocket");

            if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke();
            }
        }
        else
        {
            Debug.Log("Your Pockets are full");
        }
        
    }

    public void RemoveFromPocket(Item item)
    {
        items.Remove(item);
        Debug.Log("An Item has been removed from the pocket, there is " + items.Count + " items in the pocket");

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }
}
