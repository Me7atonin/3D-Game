using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject keyImage;       // UI Image for the key
    public GameObject keyCardImage;   // UI Image for the keycard

    // Make these public so you can see them in the Inspector
    public bool hasKey = false;  // Track if the player has the key
    public bool hasKeyCard = false;  // Track if the player has the keycard

    private void Start()
    {
        // Initially, both images should be inactive
        keyImage.SetActive(false);
        keyCardImage.SetActive(false);
    }

    private void Update()
    {
        // Update UI images based on whether the player has the items
        if (hasKey)
        {
            keyImage.SetActive(true);  // Show the key image
        }
        else
        {
            keyImage.SetActive(false);  // Hide the key image
        }

        if (hasKeyCard)
        {
            keyCardImage.SetActive(true);  // Show the keycard image
        }
        else
        {
            keyCardImage.SetActive(false);  // Hide the keycard image
        }
    }

    // Methods to add or remove items from the inventory
    public void AddItem(string itemTag)
    {
        if (itemTag == "Key")
        {
            hasKey = true;  // Add the key to the inventory
        }
        else if (itemTag == "KeyCard")
        {
            hasKeyCard = true;  // Add the keycard to the inventory
        }
    }

    public void UseItem(string itemTag)
    {
        if (itemTag == "Key" && hasKey)
        {
            hasKey = false;  // Remove the key from the inventory
            keyImage.SetActive(false);  // Hide the key image in the HUD
        }
        else if (itemTag == "KeyCard" && hasKeyCard)
        {
            hasKeyCard = false;  // Remove the keycard from the inventory
            keyCardImage.SetActive(false);  // Hide the keycard image in the HUD
        }
    }


    // Accessor methods to check if the player has the items
    public bool HasKey()
    {
        return hasKey;
    }

    public bool HasKeyCard()
    {
        return hasKeyCard;
    }
}
