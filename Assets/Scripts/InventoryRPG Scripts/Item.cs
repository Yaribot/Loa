using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Practice/Inventory/Item")]
public class Item : ScriptableObject
{
    public int iD;
    new public string name = "New Item";
    public Sprite icon = null;

}
