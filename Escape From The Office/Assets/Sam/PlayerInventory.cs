using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventorySlot slot1;  
    public InventorySlot slot2;


    public void InteractWithItem(Item item)
    {
        if (item.itemType == ItemType.Keycard)
        {
            slot1.AddItem(item);  // Place the keycard in Slot 1
            Debug.Log("Picked up Keycard and placed it in Slot 1");
        }
        else if (item.itemType == ItemType.Key)
        {
            slot2.AddItem(item);  // Place the key in Slot 2
            Debug.Log("Picked up Key and placed it in Slot 2");
        }

        // Optionally, destroy the item in the world after it's picked up and placed in the inventory
        Destroy(item.gameObject);
    }

}
