using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Seed", menuName = "InventorySystem/Item/Seed")]

public class Seed : ItemScript
{
    public int daysToGrow;
    public void Awake()
    {
        type = ItemType.Seed;
    }

}
