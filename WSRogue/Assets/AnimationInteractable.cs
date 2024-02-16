using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]Animator animation;

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
        animation.Play("Opening");
    }

}
