using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerController : MonoBehaviour
{
    // Components
    PlayerMovement pM;

    [Header("Stats")]
    private float currentHealth;
    private float maxHealth;


    private void Awake()
    {
        pM = GetComponent<PlayerMovement>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageIn)
    {
        currentHealth -= damageIn;

        if(currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        // ADD stuff to die

    }
}
