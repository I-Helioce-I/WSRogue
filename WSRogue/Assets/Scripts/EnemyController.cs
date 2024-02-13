using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Grounded,
    Flying,
    Turret
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyType enemyType;

    [SerializeField] Rigidbody rb;

    [Header("Stats")]
    float currentHealth;
    [SerializeField] float maxHealth;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageIn)
    {
        currentHealth -= damageIn;


        if (currentHealth < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    


}
