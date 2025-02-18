using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public Sprite[] itemImages;
    public string requiredItemName = "Key";
    public float pickUpRange = 3f;

    private Camera playerCamera;
    private bool isHoldingItem;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        isHoldingItem = HasItemInInventory(requiredItemName);

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpItem();
        }
    }

    void TryPickUpItem()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, pickUpRange))
        {
            if (hit.collider.CompareTag("Pickable"))
            {
                GameObject item = hit.collider.gameObject;

                if (item.CompareTag("HealthPotion"))
                {
                    AddItemToInventory(itemImages[0], "HealthPotion");
                }
                else if (item.CompareTag("Key"))
                {
                    AddItemToInventory(itemImages[1], "Key");
                }

                Destroy(item);
            }
        }
    }

    void AddItemToInventory(Sprite itemSprite, string itemName)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].slotImage.sprite == null)
            {
                inventorySlots[i].slotImage.sprite = itemSprite;
                break;
            }
        }
    }
    

    bool HasItemInInventory(string itemName)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].slotImage.sprite != null && inventorySlots[i].slotImage.sprite.name == itemName)
            {
                return true;
            }
        }
        return false;
    }
}
