using TMPro;
using UnityEngine;

public class ItemInteractionUI : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactableLayer;
    public GameObject interactHUD;
    public TextMeshProUGUI hudText;
    public InventoryUIManager inventoryUIManager;  // Reference to InventoryUIManager
    public AudioClip doorDestroySound;
    private ObjectiveManager objectiveManager;

    private void Start()
    {
        objectiveManager = FindObjectOfType<ObjectiveManager>(); // Get the ObjectiveManager
    }

    private void Update()
    {
        if (inventoryUIManager == null || interactHUD == null || hudText == null)
        {
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactDistance, interactableLayer))
        {
            if (hit.collider.CompareTag("Key") || hit.collider.CompareTag("KeyCard"))
            {
                interactHUD.SetActive(true);
                hudText.text = "Press E to Grab";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventoryUIManager.AddItem(hit.collider.tag);  // Add item to inventory
                    interactHUD.SetActive(false);
                    Destroy(hit.collider.gameObject);

                    // Add new objectives when picking up a key or keycard
                    if (hit.collider.CompareTag("Key"))
                    {
                        // Remove the "Find the key" objective when the player picks up the key
                        objectiveManager.RemoveObjective("Find the key to open this door.");
                        // Add the objective to "Open the Key Door"
                        objectiveManager.AddObjective("Open the Key Door.");
                    }
                    else if (hit.collider.CompareTag("KeyCard"))
                    {
                        // Remove the "Find the keycard" objective when the player picks up the keycard
                        objectiveManager.RemoveObjective("Find the keycard to open this door.");
                        // Add the objective to "Open the KeyCard Door"
                        objectiveManager.AddObjective("Open the KeyCard Door.");
                    }
                }
            }
            else if (hit.collider.CompareTag("Door"))
            {
                interactHUD.SetActive(true);
                hudText.text = "Press E to Open";

                var doorInteraction = hit.collider.GetComponent<DoorInteraction>();
                if (doorInteraction == null)
                {
                    return;
                }

                bool canOpen = false;

                if ((inventoryUIManager.HasKeyCard() && doorInteraction.requiresKeyCard) ||
                    (inventoryUIManager.HasKey() && doorInteraction.requiresKey))
                {
                    canOpen = true;  // We can open the door if the right item is in the inventory
                }

                if (canOpen && Input.GetKeyDown(KeyCode.E))
                {
                    PlayDoorDestroySound();
                    Destroy(hit.collider.gameObject); // Destroy the door after it opens

                    // Remove the appropriate "Open the Key Door" or "Open the KeyCard Door" objective after using the key
                    if (inventoryUIManager.HasKeyCard() && doorInteraction.requiresKeyCard)
                    {
                        objectiveManager.RemoveObjective("Open the KeyCard Door.");
                    }
                    else if (inventoryUIManager.HasKey() && doorInteraction.requiresKey)
                    {
                        objectiveManager.RemoveObjective("Open the Key Door.");
                    }
                }
            }
            else
            {
                interactHUD.SetActive(false);
            }
        }
        else
        {
            interactHUD.SetActive(false);
        }
    }

    private void PlayDoorDestroySound()
    {
        if (doorDestroySound != null)
        {
            AudioSource.PlayClipAtPoint(doorDestroySound, transform.position);
        }
    }
}
