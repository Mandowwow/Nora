using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        RedDevil,
        BlueDevil,
        VioletDevil,
        HeartBlossom,
    }

    public ItemType itemType;
    public int amount;
}
