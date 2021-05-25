using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrderGenerator : Node
{
    private List<Item> stockItems;
    private SpiritAI ai;

    public OrderGenerator(List<Item> stockItems, SpiritAI ai)
    {
        this.stockItems = stockItems;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        SpiritOrder();
        
        throw new System.NotImplementedException();
    }

    private List<Item> SpiritOrder()
    {
        //Item[] oderedItems = new Item[]{};
        List<Item> orderedItems = new List<Item>();
        System.Random random = new System.Random();

        for (int i = 0; i < 4; i++)
        {
            orderedItems.Add(stockItems[random.Next(0, stockItems.Count + 1)]);
        }
        Debug.Log(orderedItems);
        return orderedItems;
    }
}
