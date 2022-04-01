
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewInventory", menuName = "ItemSystem/Inventory")]
public class InventoryScriptableObject : ScriptableObject
{
    public List<InventorySlot> listOfItems = new List<InventorySlot>();
    public void AddItem(ItemScriptableObject _item, int _count, Sprite _itemIcon)
    {
        bool foundItem = false;
        for (int i = 0; i < listOfItems.Count; i++)
        {
            if (listOfItems[i].item == _item)
            {
                listOfItems[i].AddQuantity(_count);
                foundItem = true;
                break;
            }
        }
        if (!foundItem)
        {
            listOfItems.Add(new InventorySlot(_item, _count, _itemIcon));
        }
    }
    public void RemoveItem(ItemScriptableObject _item, int _count)
    {
        bool itemRemoved = false;
        for (int i = 0; i < listOfItems.Count; i++)
        {
            if (listOfItems[i].item == _item)
            {


                listOfItems.RemoveAt(i);
                itemRemoved = true;
                break;
            }
        }


    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemScriptableObject item;
    public int quantity;
    public Sprite itemIcon;
    public InventorySlot(ItemScriptableObject _item, int _amount, Sprite _icon)
    {
        item = _item;
        quantity = _amount;
        itemIcon = _icon;
    }
    public void AddQuantity(int count)
    {
        quantity += count;
    }
    public void SubtractQuantity(int count)
    {
        if (quantity > 1)
            quantity -= count;
        else if (quantity == 1)
            quantity = 1;
        else
            quantity = -1;
    }
}