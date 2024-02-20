using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] CinemachineVirtualCamera shopCamera;
    bool isOpen = false;
    [SerializeField] string text = "Open";
    [SerializeField] Animator animator;

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
            animator.SetBool("IsOpen", false);
            CloseShop();
            playerInteract.GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            playerInteract.GetComponent<PlayerMovement>().enabled = true;
            playerInteract.playerInteractUI.containerGameObject.SetActive(true);

        }
        else
        {
            animator.SetBool("IsOpen", true);
            OpenShop();
            playerInteract.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            playerInteract.GetComponent<PlayerMovement>().enabled = false;
            playerInteract.playerInteractUI.containerGameObject.SetActive(false);
            playerInteract.playerInteractUI.enabled = false;
        }
    }

    private void OpenShop()
    {
        shopCamera.gameObject.SetActive(true);
        isOpen = true;
    }

    private void CloseShop()
    {
        shopCamera.gameObject.SetActive(false);
        isOpen = false;
    }


}
