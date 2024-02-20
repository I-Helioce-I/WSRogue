using Cinemachine.Utility;
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Components
    PlayerController pC;
    Controller inputActions;
    Rigidbody rb = null;
    Animator animator = null;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    float defaultMoveSpeed;
    float horizontalMovement;
    float maxSpeed;
    float backwardSpeed;

    [Header("Jump")]
    [SerializeField] float jumpForce = 10f;
    [SerializeField] private int maxJumps = 2;
    int jumpsRemaining;
    bool isJumping;
    bool isGrounded;

    [Header("Dash")]
    [SerializeField] float dashingPower = 20f;
    [SerializeField] float dashingCooldown = 10f;
    [SerializeField] TrailRenderer trail;
    public float timerDash;

    bool canDash;
    bool isDashing;

    [Header("Aim")]
    [SerializeField] GameObject crosshair;
    [SerializeField] GameObject caspule;
    public bool isFacingRight;
    [SerializeField] GameObject originShoot;

    private void Awake()
    {
        inputActions = new Controller();
        pC = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        canDash = true;
        defaultMoveSpeed = moveSpeed;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Update()
    {
        if (!canDash)
        {
            timerDash -= Time.deltaTime;

            if (timerDash <= 0)
            {
                canDash = true;
            }
        }
    }

    private void FixedUpdate()
    {
        SpeedControl();
        rb.velocity = new Vector3(horizontalMovement * (moveSpeed / backwardSpeed), rb.velocity.y);
        WalkAnimation();
        IsGrounded();
    }

    public void Move(InputAction.CallbackContext value)
    {
        horizontalMovement = value.ReadValue<Vector2>().y;
    }

    //Ce qui ralentit le backward
    private void SpeedControl()
    {
        if (isFacingRight)
        {
            if ((horizontalMovement < 0))
            {
                backwardSpeed = 2;
            }
            else
            {
                backwardSpeed = 1;
            }
        }
        else
        {
            if (horizontalMovement > 0)
            {
                backwardSpeed = 2;
            }
            else
            {
                backwardSpeed = 1;
            }
        }
    }

    private void WalkAnimation()
    {
        if (isFacingRight)
        {
            animator.SetFloat("Speed", rb.velocity.x);
        }
        else
        {
            animator.SetFloat("Speed", -rb.velocity.x);
        }
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (jumpsRemaining > 0)
        {
            if (value.performed)
            {
                if (!isJumping)
                {
                    animator.SetTrigger("IsJumping");
                    Debug.Log("Trigger");
                }
                isJumping = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpsRemaining--;
            }
            else if (value.canceled) // la c'est plus tu reste appuyé plus ça saute haut / retiré le else if si on veux pas
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }


        }
    }

    public void Dash(InputAction.CallbackContext value)
    {
        if (value.performed && canDash)
        {
            trail.enabled = true;
            animator.Play("Dash");
            rb.AddForce(new Vector3(horizontalMovement, 0) * dashingPower, ForceMode.Impulse);
            timerDash = dashingCooldown;
            canDash = false;
            trail.enabled = false;
        }
    }

    public void Aim(InputAction.CallbackContext value)
    {
        if (value.performed)
        {

            Vector3 mousePosition = value.ReadValue<Vector2>();
            if (mousePosition.x < Screen.width / 2)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -90, transform.rotation.z));
                isFacingRight = false;
            }
            else if (mousePosition.x > Screen.width / 2)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90, transform.rotation.z));
                isFacingRight = true;
            }

        }
        else if (value.canceled)
        {
            return;
        }
    }

    private void IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {

            jumpsRemaining = maxJumps;
            animator.SetBool("IsGrounded", true);
            animator.SetBool("IsFalling", false);
            isJumping = false;
        }
        else
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsGrounded", false);
        }
    }
}
