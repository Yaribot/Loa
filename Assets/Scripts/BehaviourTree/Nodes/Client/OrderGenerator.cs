using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrderGenerator : Node
{
    private List<Item> stockItems;
    private IntVariable nbItemsOrdered;
    private SpiritAI ai;

    public OrderGenerator(List<Item> stockItems, IntVariable nbItemsOrdered, SpiritAI ai)
    {
        this.stockItems = stockItems;
        this.nbItemsOrdered = nbItemsOrdered;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        
        if (SpiritOrder() == null)
        {
            return NodeState.FAILURE;
        }
        else
        {
            return NodeState.SUCCCESS;
        }
    }

    /// <summary>
    /// Generate a random number of random items in the stock
    /// </summary>
    /// <returns></returns>
    private List<Item> SpiritOrder()
    {
        //Item[] oderedItems = new Item[]{};
        List<Item> orderedItems = new List<Item>();
        System.Random randomNb = new System.Random();
        System.Random randomItems = new System.Random();

        for (int i = 0; i < randomNb.Next(1,nbItemsOrdered.Value); i++) 
        {
            orderedItems.Add(stockItems[randomItems.Next(0, stockItems.Count)]);
        }
        foreach (Item items in orderedItems)
        {
            Debug.Log(items.name);
        }
        Debug.Log(orderedItems.Count);
        return orderedItems;
    }
}
