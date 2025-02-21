using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject keyImage;       // UI Image for the key
    public GameObject keyCardImage;   // UI Image for the keycard

    private Inventory inventory;  // Reference to the Inventory script

    private void Start()
    {
        inventory = GetComponent<Inventory>();  // Get the Inventory script on the same GameObject

        // Initially deactivate both UI images
        keyImage.SetActive(false);
        keyCardImage.SetActive(false);
    }

    private void Update()
    {
        // Check if the player has the key and keycard in their inventory
        if (inventory.hasKey)
        {
            keyImage.SetActive(true);  // Show the key image
        }
        else
        {
            keyImage.SetActive(false);  // Hide the key image
        }

        if (inventory.hasKeyCard)
        {
            keyCardImage.SetActive(true);  // Show the keycard image
        }
        else
        {
            keyCardImage.SetActive(false);  // Hide the keycard image
        }
    }
}
