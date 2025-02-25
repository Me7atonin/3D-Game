using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<string> items = new List<string>();  // List to store the items

    // Add item to the inventory
    public void AddItem(string itemTag)
    {
        if (!items.Contains(itemTag))
        {
            items.Add(itemTag);  // Add the item to the inventory
        }
    }

    // Remove item from the inventory
    public void UseItem(string itemTag)
    {
        if (items.Contains(itemTag))
        {
            items.Remove(itemTag);  // Remove the item from the inventory
        }
    }

    // Check if the inventory contains the item
    public bool HasItem(string itemTag)
    {
        return items.Contains(itemTag);  // Returns true if the item exists in the inventory
    }
}
