using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Components
    PlayerController pC;
    Controller inputActions;
    Rigidbody rb = null;


    [Header("Movement")]
    [SerializeField] float moveSpeed = 5f;
    float horizontalMovement;
    float maxSpeed;

    [Header("Jump")]
    [SerializeField] float jumpForce = 10f;
    [SerializeField] private int maxJumps = 2;
    int jumpsRemaining;

    [Header("Dash")]
    bool canDash;
    bool isDashing;
    [SerializeField] float dashingPower = 20f;
    [SerializeField] float dashingCooldown = 10f;
    public float timerDash;

    private void Awake()
    {
        inputActions = new Controller();
        pC = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        canDash = true;
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

        MousePosition();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalMovement * moveSpeed, rb.velocity.y);
        IsGrounded();
    }

    public void Move(InputAction.CallbackContext value)
    {
        horizontalMovement = value.ReadValue<Vector2>().x;

    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (jumpsRemaining > 0)
        {

            if (value.performed)
            {
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

            rb.AddForce(new Vector3(horizontalMovement,0) * dashingPower, ForceMode.Impulse);
            timerDash = dashingCooldown;
            canDash = false;
        }
    }

    public void MousePosition()
    {
        
    }

    

    private void IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {
            jumpsRemaining = maxJumps;

        }
    }
}
