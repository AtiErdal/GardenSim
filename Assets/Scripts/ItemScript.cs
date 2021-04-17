using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Seed,
    Plant,
    Equipment
}

public enum Prices
{
    BuyPrice,
    SellPrice
}
public abstract class ItemScript : ScriptableObject
{
    public Price[] price;

    public Sprite uiDisplay;
    public ItemType type;
    public string desc;
    public Sprite icon;
    public int amount = 1;
    public bool stackable;
    public Item data = new Item();
    
    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }

    public void PriceModified(Price price)
    {
        Debug.Log(string.Concat(price.price, "was updated! Price is now ", price.value.ModifiedValue));
    }
}
[System.Serializable]
public class Item
{
    public string Name;
    public int ID = -1;
    public int amount;
    public int price;
    public Item()
    {
        Name = "";
        ID = -1;
    }
    public Item(ItemScript item)
    {
        Name = item.name;
        ID = item.data.ID;
        amount = item.amount;
        price = item.data.price;
    }
}



[System.Serializable]
public class ItemPrice : IModifiers
{
    public Prices price;
    public int value;
    public int min;
    public int max;

    public ItemPrice (int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateField();
    }
    public void AddValue(ref int baseValue)
    {
        baseValue += value;
    }
    public void GenerateField()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}

public class Price
{
    [System.NonSerialized]
    public ItemScript parent;
    public Prices price;
    public ModifiableInt value;
    
    public void SetParent(ItemScript _parent)
    {
        parent = _parent;
        value = new ModifiableInt(PriceModified);
    }
    public void PriceModified()
    {
        parent.PriceModified(this);
    }
}
