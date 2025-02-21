using TMPro;
using UnityEngine;

public class ItemInteractionUI : MonoBehaviour
{
    public float interactDistance = 3f;  // Distance at which the player can interact with items
    public LayerMask interactableLayer;  // Layer for interactable objects (items like Key, KeyCard, and Door)
    public GameObject interactHUD;  // UI Text for "Press E to Grab"
    public TextMeshProUGUI hudText;  // HUD text component to display different messages
    public Inventory inventory;  // Reference to the inventory to check for items

    private void Update()
    {
        RaycastHit hit;

        // Raycast from the center of the camera (the player's viewpoint)
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactDistance, interactableLayer))
        {
            // If the player is close to an item like Key or KeyCard
            if (hit.collider.CompareTag("Key") || hit.collider.CompareTag("KeyCard"))
            {
                // Show "Press E to Grab" text
                interactHUD.SetActive(true);
                hudText.text = "Press E to Grab";

                // If the player presses 'E', pick up the item
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Add the item to the inventory
                    inventory.AddItem(hit.collider.tag);

                    // Hide the interaction UI text after picking up
                    interactHUD.SetActive(false);

                    // Destroy the item after picking it up
                    Destroy(hit.collider.gameObject);
                }
            }
            // If the player is close to a door
            else if (hit.collider.CompareTag("Door"))
            {
                // Show "Press E to Interact" text
                interactHUD.SetActive(true);
                hudText.text = "Press E to Open";

                // If the player presses 'E' and has the right key
                if ((inventory.hasKeyCard && hit.collider.GetComponent<DoorInteraction>().requiresKeyCard) ||
                    (inventory.hasKey && hit.collider.GetComponent<DoorInteraction>().requiresKey))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // Trigger the door opening animation
                        hit.collider.GetComponent<Animator>().SetTrigger("OpenDoor");
                    }
                }
            }
            else
            {
                // Hide the UI text if nothing is being hovered over
                interactHUD.SetActive(false);
            }
        }
        else
        {
            // Hide the UI text if nothing is being hovered over
            interactHUD.SetActive(false);
        }
    }
}
