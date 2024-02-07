using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerInteract : MonoBehaviour
{
    public void InteractInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact(this);
            }
        }

    }

    public IInteractable GetInteractableObject()
    {
        List<IInteractable> _interactableList = new List<IInteractable>();
        float _interactRange = 2f;
        Collider[] _collidersArray = Physics.OverlapSphere(transform.position, _interactRange);

        foreach (Collider collider in _collidersArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                _interactableList.Add(interactable);

            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in _interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
                {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}
