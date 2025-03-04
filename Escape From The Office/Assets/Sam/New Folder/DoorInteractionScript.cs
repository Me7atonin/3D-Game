using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    // Example variables that determine whether the door requires a key or keycard
    public bool requiresKey = false;
    public bool requiresKeyCard = false;

    // Add your animation or other states for opening the door
    private Animator anim; // Assuming you are using an Animator for door animations

    void Start()
    {
        // Optional: Get the animator if you're using animations for doors
        anim = GetComponent<Animator>();
    }

    // Mark the door as interacted with (e.g., unlocked or opened)
    public void MarkAsInteracted()
    {
        if (requiresKey)
        {
            // If the door requires a key, we unlock it (or open it, based on your design)
            Debug.Log(gameObject.name + " has been unlocked with the key.");

            // Example: You could trigger an animation to open the door
            if (anim != null)
            {
                anim.SetTrigger("Open");  // Trigger an "Open" animation (if you have one set up in the Animator)
            }

            // If the door was locked and you need to change its state, you can do so here
            // For example, if the door has a collider and you want it to be interactable, enable it
            // GetComponent<Collider>().enabled = true; // or whatever behavior suits your needs
        }

        if (requiresKeyCard)
        {
            // If the door requires a keycard, we unlock it or perform another action
            Debug.Log(gameObject.name + " has been unlocked with the keycard.");

            if (anim != null)
            {
                anim.SetTrigger("Open");  // Trigger the open animation
            }

            // Again, handle whatever state change you'd like when the keycard is used
        }
    }
}
