using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]Animator animator;
    [SerializeField] Animator doorAnimator;
    public string GetInteractText()
    {
        return "Open";
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void Interact(PlayerInteract playerInteract)
    {
        animator.SetBool("OpenTheDoor", true);

        if(doorAnimator != null)
        {
            doorAnimator.SetBool("IsUncover", true);
        }
        Destroy(this);
    }

}
