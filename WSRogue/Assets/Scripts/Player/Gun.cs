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
    PlayerMovement pM;


    [SerializeField] int currentAmmo;
    [SerializeField] int maxAmmo;
    [SerializeField] float cooldown;
    [SerializeField] bool isRecharging;
    bool canShoot;

    private Camera mainCamera;
    private Vector3 mousePos;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        currentAmmo = maxAmmo;
        mainCamera = Camera.main;
        pM = GetComponent<PlayerMovement>();
    }

    public void Shoot(InputAction.CallbackContext value)
    {
        if (value.performed && canShoot)
        {
            animator.Play("Shoot");
            currentAmmo--;
            Debug.Log("Shoot");
            Shoot();
        }

    }

    public void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, origin.transform.position, origin.transform.rotation);
        if (pM.isFacingRight)
        {

            bullet.GetComponent<ProjectileMovement>().direction = Vector3.right;
        }
        else
        {

            bullet.GetComponent<ProjectileMovement>().direction = Vector3.left;
        }
    }

    private void Update() 
    {
        if (currentAmmo > 0 && !canShoot)
        {
            canShoot = true;
        }


    }
}
