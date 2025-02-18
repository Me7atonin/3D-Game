using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public string requiredItemName = "Key";
    public float interactionRange = 3f;
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteractWithDoor();
        }
    }

    void TryInteractWithDoor()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange))
        {
            if (hit.collider.CompareTag("Door"))
            {
                PlayerInventory playerInventory = GetComponent<PlayerInventory>();

                if (playerInventory != null && playerInventory.HasItemInInventory(requiredItemName))
                {
                    InteractWithDoor(hit.collider.gameObject);
                }
                else
                {
                    Debug.Log("You need a key to unlock this door!");
                }
            }
        }
    }

    void InteractWithDoor(GameObject door)
    {
        Debug.Log("The door is now unlocked!");
        door.SetActive(false);
    }
}
