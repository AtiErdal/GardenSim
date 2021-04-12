using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipment", menuName = "InventorySystem/Item/Equipment")]
public class Equipment : ItemScript
{

    public void Awake()
    {
        type = ItemType.Equipment;
    }

}
