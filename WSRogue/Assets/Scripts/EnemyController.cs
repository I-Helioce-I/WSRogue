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

    [SerializeField] PlayerController playerController;

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

    private void Update()
    {
        if(playerController != null)
        {
            switch (enemyType)
            {
                case EnemyType.Grounded:
                    break;
                case EnemyType.Flying:
                    break;
                case EnemyType.Turret:
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            playerController = player;
        }
    }

}
