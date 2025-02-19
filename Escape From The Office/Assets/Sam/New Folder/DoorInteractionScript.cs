using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public bool requiresKeyCard = false;
    public bool requiresKey = false;
    public Animator doorAnimator;  // To control the door animation

    // You can keep this simple, as the logic is handled in the ItemInteraction script now.
}
