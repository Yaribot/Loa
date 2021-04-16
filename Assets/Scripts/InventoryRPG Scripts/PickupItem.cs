using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public Item item;
    public Image icon;
    private void Start()
    {
        icon.sprite = item.icon;
    }
    public void PickUp()
    {
        Debug.Log("Picking up" + item.name);
        InventoryPocket.instance.AddToPocket(item);
    }
}
