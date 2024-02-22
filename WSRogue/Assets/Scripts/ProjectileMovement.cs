using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    [SerializeField] float speed;
    [SerializeField] Projectile projectilComponent;
    Rigidbody rb;
    float damage;

    public float Damage { get { return damage; } set { damage = value; } }

    private void Awake()
    {
        projectilComponent = GetComponent<Projectile>();
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 2);
    }


    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3 || other.gameObject.layer == 6)
        {

            if (other.gameObject.transform.parent.TryGetComponent<EnemyController>(out EnemyController enemy))
            {
                if (enemy.canTakeShoot)
                {

                    enemy.TakeDamage(damage);
                }
            }
            else if (other.gameObject.transform.parent.TryGetComponent<PlayerController>(out PlayerController player))
            {
                player.TakeDamage(damage);
            }

        }
    }
}
