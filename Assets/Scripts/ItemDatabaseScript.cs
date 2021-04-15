using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Database", menuName = "InventorySystem/Items/Database")]
public class ItemDatabaseScript : ScriptableObject, ISerializationCallbackReceiver
{
    
    public ItemScript[] Items;

    [ContextMenu("Ipdate ID's")]
    public void UpdateID()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].data.ID != i)
                Items[i].data.ID = i;
        }
        
    }

    public void OnAfterDeserialize()
    {
        UpdateID();
    }

    public void OnBeforeSerialize()
    {
    }
}
