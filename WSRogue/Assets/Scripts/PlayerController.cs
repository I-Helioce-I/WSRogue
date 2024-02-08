using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Components
    PlayerMovement pM;
    PlayerInteract pI;
    Animator animator;
    CombatSystem combatSystem;

    [Header("Stats")]
    private float currentHealth;
    private float maxHealth;
    bool isDead = false;


    private void Awake()
    {
        pM = GetComponent<PlayerMovement>();
        pI = GetComponent<PlayerInteract>();
        animator = GetComponentInChildren<Animator>();
        combatSystem = GetComponent<CombatSystem>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageIn)
    {
        currentHealth -= damageIn;

        if (currentHealth <= 0)
        {

        }
    }



    public void Die(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isDead = true;
            animator.SetBool("IsDead", isDead);
            pM.enabled = false;
        }

    }
}
