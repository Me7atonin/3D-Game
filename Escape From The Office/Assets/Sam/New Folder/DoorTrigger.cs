using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private ObjectiveManager objectiveManager;

    // New variable to select if the door requires a keycard or key
    public bool isKeyCardDoor = false;  // Toggle this in the Inspector to determine door type
    public bool isKeyDoor = false;  // Toggle this in the Inspector to determine door type

    private void Start()
    {
        objectiveManager = FindObjectOfType<ObjectiveManager>(); // Get the ObjectiveManager
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Add objective depending on the type of door
            if (isKeyCardDoor)
            {
                objectiveManager.AddObjective("Find the keycard to open this door.");
            }
            else if (isKeyDoor)
            {
                objectiveManager.AddObjective("Find the key to open this door.");
            }
        }
    }
}
