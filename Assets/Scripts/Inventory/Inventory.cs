using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory() {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.HeartBlossom, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item) {
        itemList.Add(item);
    }
}
