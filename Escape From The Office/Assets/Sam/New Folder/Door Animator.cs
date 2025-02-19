using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    public Animator animator;

    public void OpenDoorAnimation()
    {
        animator.SetTrigger("OpenDoor");
    }
}
