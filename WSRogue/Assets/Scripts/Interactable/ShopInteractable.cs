using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] CinemachineVirtualCamera shopCamera;
    bool isOpen = false;
    [SerializeField] string text;

    public string GetInteractText()
    {
        return text;
    }

    public Transform GetTransform()
    {

        return transform;
    }

    public void Interact(PlayerInteract playerInteract)
    {
        if (isOpen)
        {
            CloseShop();
        }
        else
        {
            OpenShop();
        }
    }

    private void OpenShop()
    {
        shopCamera.gameObject.SetActive(true);
    }

    private void CloseShop()
    {
        shopCamera.gameObject.SetActive(false);
    }


}
