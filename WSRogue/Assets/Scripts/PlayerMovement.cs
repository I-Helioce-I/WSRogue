using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new Controller();

    }

    private void OnEnable()
    {
        inputActions.Player.Jump.performed += DoJump;
    }

    private void FixedUpdate()
    {
        
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("ShouldJump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        inputActions.Player.Jump.performed -= DoJump;
    }



}
