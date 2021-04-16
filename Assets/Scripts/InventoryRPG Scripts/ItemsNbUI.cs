using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsNbUI : MonoBehaviour
{
    public InventoryPocket inventory;
    public TMP_Text itemsNb;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(inventory.items.Count);
        itemsNb.text = inventory.items.Count.ToString("you Have "+ inventory.items.Count +" items");
    }
}
