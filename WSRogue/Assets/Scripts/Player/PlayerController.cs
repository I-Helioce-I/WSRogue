using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
    [SerializeField] SkinnedMeshRenderer mat;

    // Ui 
    [SerializeField] Slider healthSlider;


    private void Awake()
    {
        pM = GetComponent<PlayerMovement>();
        pI = GetComponent<PlayerInteract>();
        animator = GetComponentInChildren<Animator>();
        combatSystem = GetComponent<CombatSystem>();
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        if (isDead)
        {

        }
    }

    public void TakeDamage(float damageIn)
    {
        currentHealth -= damageIn;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {

        }
    }

    public void Heal(float healIn)
    {
        currentHealth += healIn;
        UpdateHealthBar();

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }



    public void Die(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isDead = true;
            animator.SetBool("IsDead", isDead);
            pM.enabled = false;

            mat.material.SetFloat("_Anime", Mathf.Lerp(-1.5f, 1, 3));


        }
        else if (context.canceled)
        {
            return;
        }

    }

    private void UpdateHealthBar()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
