using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasKey = false;
    public bool hasKeyCard = false;

    // Add item to the inventory (Key or KeyCard)
    public void AddItem(string itemTag)
    {
        if (itemTag == "Key")
        {
            hasKey = true;
        }
        else if (itemTag == "KeyCard")
        {
            hasKeyCard = true;
        }
    }

    // Remove item from the inventory (when used or the level ends)
    public void RemoveItem(string itemTag)
    {
        if (itemTag == "Key")
        {
            hasKey = false;
        }
        else if (itemTag == "KeyCard")
        {
            hasKeyCard = false;
        }
    }
}
