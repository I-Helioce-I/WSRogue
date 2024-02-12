using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject origin;
    Animator animator;

    
    [SerializeField] int currentAmmo;
    [SerializeField] int maxAmmo;
    [SerializeField ] float cooldown;
    [SerializeField] bool isRecharging;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        currentAmmo = maxAmmo;
    }
 
    public void Shoot(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            animator.Play("Shoot");
            currentAmmo--;
            Debug.Log("Shoot");
        }

    }

    private void Update()
    {
        
    }
}
