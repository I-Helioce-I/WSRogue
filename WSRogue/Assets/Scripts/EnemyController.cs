using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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
    [SerializeField] bool canTakeMelee;
    [SerializeField] bool canTakeShoot;
    [SerializeField] GameObject origin;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] PlayerController playerController;

    float timer;
    [SerializeField] float coolDown = 2f;


    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        timer = coolDown;
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
        if (playerController != null)
        {
            switch (enemyType)
            {
                case EnemyType.Grounded:
                    break;
                case EnemyType.Flying:
                    break;
                case EnemyType.Turret:
                    origin.transform.LookAt(playerController.transform.position);
                    Shoot();
                    break;
                default:
                    break;
            }
        }
    }

    private void Shoot()
    {
        if (timer <= 0)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, origin.transform.position, transform.localRotation);
            timer = coolDown;
        }

        timer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.TryGetComponent<PlayerController>(out PlayerController player))
        {
            playerController = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.parent.TryGetComponent<PlayerController>(out PlayerController player))
        {
            playerController = player;
        }
    }

}
