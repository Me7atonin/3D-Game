using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private ObjectiveManager objectiveManager;
    private InventoryUIManager inventoryUIManager;

    // New variable to select if the door requires a keycard or key
    public bool isKeyCardDoor = false;  // Toggle this in the Inspector to determine door type
    public bool isKeyDoor = false;  // Toggle this in the Inspector to determine door type

    private void Start()
    {
        objectiveManager = FindObjectOfType<ObjectiveManager>(); // Get the ObjectiveManager
        inventoryUIManager = FindObjectOfType<InventoryUIManager>(); // Get the InventoryUIManager
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Only add the objective if the player has not already picked up the key/keycard
            if (isKeyCardDoor && !inventoryUIManager.HasKeyCard() && !objectiveManager.objectives.Exists(obj => obj.description == "Find the keycard to open this door." && obj.isActive))
            {
                objectiveManager.AddObjective("Find the keycard to open this door.");
            }
            else if (isKeyDoor && !inventoryUIManager.HasKey() && !objectiveManager.objectives.Exists(obj => obj.description == "Find the key to open this door." && obj.isActive))
            {
                objectiveManager.AddObjective("Find the key to open this door.");
            }
        }
    }
}
