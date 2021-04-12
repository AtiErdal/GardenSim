using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Database", menuName = "InventorySystem/Items/Database")]
public class ItemDatabaseScript : ScriptableObject, ISerializationCallbackReceiver
{
    
    public ItemScript[] Items;
    public Dictionary<int, ItemScript> GetItem = new Dictionary<int, ItemScript>();

    public void OnAfterDeserialize()
    {
        GetItem = new Dictionary<int, ItemScript>();
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].ID = i;
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetItem = new Dictionary<int, ItemScript>();
    }
}
