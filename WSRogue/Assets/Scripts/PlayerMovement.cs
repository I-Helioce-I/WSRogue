using Cinemachine.Utility;
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

    [Header("Aim")]
    [SerializeField] GameObject crosshair;
    [SerializeField] GameObject caspule;

    private void Awake()
    {
        inputActions = new Controller();
        pC = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        canDash = true;
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
        
        animator.SetFloat("Speed",Mathf.Abs(rb.velocity.x));
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
            animator.Play("Dash");
            rb.AddForce(new Vector3(horizontalMovement, 0) * dashingPower, ForceMode.Impulse);
            timerDash = dashingCooldown;
            canDash = false;
        }
    }
    
    public void Aim(InputAction.CallbackContext value)
    {
        Vector3 mousePosition = value.ReadValue<Vector2>();

        Debug.Log(mousePosition.x + "   " + Screen.width / 2);
        if (mousePosition.x < Screen.width / 2)
        {
            caspule.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, -90, transform.rotation.z));
        }
        else if (mousePosition.x > Screen.width / 2)
        {
            caspule.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90, transform.rotation.z));
        }
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
