using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotImage;  // UI image to display the item
    public Item currentItem; // Reference to the current item in this slot

    // Add an item to the slot
    public void AddItem(Item item)
    {
        currentItem = item;
        // Update the UI image for the item in the slot
        slotImage.sprite = item.itemIcon;
    }

    // Remove the item from the slot
    public void RemoveItem()
    {
        currentItem = null;
        slotImage.sprite = null; // Clear the UI slot image
    }
}
