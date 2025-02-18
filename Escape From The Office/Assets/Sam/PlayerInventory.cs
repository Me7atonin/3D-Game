using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventorySlot slot1;  
    public InventorySlot slot2;  

    
    public void InteractWithItem(Item item)
    {
        
        if (item.itemType == ItemType.Keycard)
        {
            slot1.AddItem(item);  
        }
        else if (item.itemType == ItemType.Key)
        {
            slot2.AddItem(item);  
        }

        
        Destroy(item.gameObject);
    }
}
