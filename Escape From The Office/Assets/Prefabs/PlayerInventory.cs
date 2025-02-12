using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public InventorySlot[] inventorySlots; // Array of inventory slots (minimum 2)
    public Sprite[] itemImages; // Array of images for different items (should match item types)

    private Camera playerCamera; // The player's camera
    private float pickUpRange = 3f; // Range to pick up items

    void Start()
    {
        playerCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpItem();
        }
    }

    void TryPickUpItem()
    {
        RaycastHit hit;

        // Cast a ray from the camera to check if it hits an item
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange))
        {
            // Check if the object has the "Pickable" tag
            if (hit.collider.CompareTag("Pickable"))
            {
                GameObject item = hit.collider.gameObject;

                // Example of how you could handle different items based on tags
                if (item.CompareTag("HealthPotion"))
                {
                    // Find the first empty slot (for simplicity, this checks only two slots)
                    for (int i = 0; i < inventorySlots.Length; i++)
                    {
                        if (inventorySlots[i].slotImage.sprite == null)  // Check if the slot is empty
                        {
                            inventorySlots[i].slotImage.sprite = itemImages[0]; // Set sprite for health potion
                            break;
                        }
                    }
                }
                else if (item.CompareTag("ManaPotion"))
                {
                    // Find the first empty slot (for simplicity, this checks only two slots)
                    for (int i = 0; i < inventorySlots.Length; i++)
                    {
                        if (inventorySlots[i].slotImage.sprite == null)  // Check if the slot is empty
                        {
                            inventorySlots[i].slotImage.sprite = itemImages[1]; // Set sprite for mana potion
                            break;
                        }
                    }
                }

                // Optionally, destroy the item after picking it up
                Destroy(item);
            }
        }
    }
}

