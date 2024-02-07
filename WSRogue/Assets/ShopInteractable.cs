using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] CinemachineVirtualCamera shopCamera;
    public string GetInteractText()
    {
        return "Shop";
    }

    public Transform GetTransform()
    {

        return transform;
    }

    public void Interact(PlayerInteract playerInteract)
    {
        OpenShop();
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
