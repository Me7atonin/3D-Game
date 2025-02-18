using UnityEngine;
using System.Collections;
public class Interaction : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
        void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2))
        {
            if (hit.collider.tag.Equals("Interact"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    
                }
            }
        }
    }
}