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
                    Destroy(hit.collider.gameObject);

                    // Now we need to uncheck the checkbox and turn off the image of the used item
                    if (inventoryUIManager.HasKeyCard())
                    {
                        inventoryUIManager.UseItem("KeyCard");  // Remove the keycard
                        inventoryUIManager.keyCardImage.SetActive(false);  // Turn off the image for the keycard
                    }
                    else if (inventoryUIManager.HasKey())
                    {
                        inventoryUIManager.UseItem("Key");  // Remove the key
                        inventoryUIManager.keyImage.SetActive(false);  // Turn off the image for the key
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
