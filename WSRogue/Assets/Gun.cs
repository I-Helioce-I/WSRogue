using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject origin;
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Shoot(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            animator.Play("Shoot");
            Debug.Log("Shoot");
        }




    }
}
