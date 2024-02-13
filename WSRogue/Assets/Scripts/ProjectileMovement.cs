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

    private void Awake()
    {
        projectilComponent = GetComponent<Projectile>();
        rb = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        rb.AddForce(direction * speed, ForceMode.Impulse);
    }
}
