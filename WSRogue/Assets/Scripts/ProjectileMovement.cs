using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public enum Direction
    {
        Forward,
        Backward,
        Left,
        Right,
        Top,
        Down
    }

    [SerializeField] Direction currentDirection;
    public Vector3 direction = Vector3.right;
    [SerializeField] float speed;
    [SerializeField] Projectile projectilComponent;
    Rigidbody rb;
    float damage;

    public float Damage { get { return damage; } set {  damage = value; } }

    private void Awake()
    {
        projectilComponent = GetComponent<Projectile>();
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 2);
    }


    private void Update()
    {
        transform.Translate(Vector3.forward* speed * Time.deltaTime);
    }
}
