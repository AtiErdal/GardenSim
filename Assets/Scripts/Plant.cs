using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "InventorySystem/Item/Plant")]
public class Plant : ItemScript
{
    public bool grown;
    public void Awake()
    {
        type = ItemType.Plant;
    }

}

