using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public GameObject interactCanvas;  // UI canvas for interaction prompt
    public Text interactText;          // Text for the interaction prompt
    public PlayerInventory playerInventory;
    public float interactRange = 3f;   // Range to detect doors

    private Door doorScript;           // Reference to the Door script

    void Start()
    {
        interactCanvas.SetActive(false); // Hide the interact UI by default
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerInventory.transform.position, playerInventory.transform.forward, out hit, interactRange))
        {
            if (hit.collider.CompareTag("Door"))
            {
                doorScript = hit.collider.GetComponent<Door>(); // Get the Door script from the door

                if (doorScript != null)
                {
                    interactCanvas.SetActive(true);  // Show the interact canvas
                    interactText.text = "Press 'E' to interact"; // Show the prompt

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        InteractWithDoor(doorScript);
                    }
                }
            }
        }
        else
        {
            interactCanvas.SetActive(false); // Hide the interact canvas when not near a door
        }
    }

    void InteractWithDoor(Door door)
    {
        // Check if the player has the required item in the corresponding slot
        bool hasKeycard = playerInventory.slot1.currentItem != null && playerInventory.slot1.currentItem.itemType == ItemType.Keycard;
        bool hasKey = playerInventory.slot2.currentItem != null && playerInventory.slot2.currentItem.itemType == ItemType.Key;

        // If the door requires a keycard and the player has one, or if the door requires a key and the player has one
        if ((door.requiresKeycard && hasKeycard) || (door.requiresKey && hasKey))
        {
            Debug.Log("Door unlocked!");

            // You can trigger the door's opening animation or other logic here
            // Example: doorAnimator.SetTrigger("OpenDoor");

            // Remove the item from the slot (destroy it from the inventory)
            if (door.requiresKeycard && hasKeycard)
            {
                playerInventory.slot1.RemoveItem();  // Remove the keycard
            }
            else if (door.requiresKey && hasKey)
            {
                playerInventory.slot2.RemoveItem();  // Remove the key
            }
        }
        else
        {
            Debug.Log("You need the correct item to unlock the door!");
        }
    }
}
