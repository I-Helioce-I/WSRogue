using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    // Components
    PlayerController pC;
    Controller inputActions;
    Rigidbody rb;

    // Values
    [Header("Stats")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    float maxSpeed;

    private void Awake()
    {
        inputActions = new Controller();
        rb = GetComponent<Rigidbody>();
        
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Jump.started += DoJump;
        
        inputActions.Player.Enable();
    }

    private void FixedUpdate()
    {
        

        if (rb.velocity.y < 0f)
        {
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }
        
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Jump.started += DoJump; // Checker si c'est pas -= plutot que +=
        //inputActions.Player.Interact.canceled -= OnInteract;
        
        inputActions.Player.Disable();
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            transform.position += Vector3.up * jumpForce;
        }
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {

    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}
