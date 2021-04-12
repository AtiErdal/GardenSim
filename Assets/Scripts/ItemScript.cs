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
    public Sprite uiDisplay;
    public int ID;
    public ItemType type;
    public string desc;
    public Sprite icon;
    public int amount = 1;
    public int price;
    public bool isPickable;
    public bool pickedUp;
    


    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}
[System.Serializable]
public class Item
{
    public string Name;
    public int ID;
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
        ID = item.ID;
        amount = item.amount;
        price = item.price;
    }
}

public class Price
{
    public Prices price;
    public int value;

}
