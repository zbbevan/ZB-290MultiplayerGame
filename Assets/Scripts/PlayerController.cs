using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public int playerID = 1;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    private Vector2 moveInput;
    private bool jumpInput;
    private bool dashInput;
    private PlayerInput playerInput;
    private Rigidbody rb;

    private bool canJump = true;
    private bool canDash = true;
    private bool canDoubleJump = false;
    [SerializeField] private float dashCoolTime = 2f;
    [SerializeField] private float dashSpeed = 10f;

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        jumpInput = playerInput.actions["Jump"].WasPressedThisFrame();
        dashInput = playerInput.actions["Sprint"].WasPressedThisFrame();
        
        
        if (jumpInput && canJump)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            canJump = false;
            canDoubleJump = true;
        }
        else if (jumpInput && canDoubleJump && !canJump)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            canDoubleJump = false;
        }

        if (dashInput && canDash)
        {
            rb.AddForce(moveInput * dashSpeed, ForceMode.VelocityChange);
            canDash = false;
            StartCoroutine(DashCooldown());
        }


    }

    void FixedUpdate()
    {
       rb.AddRelativeForce(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }


    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCoolTime);
        canDash = true;
    }


}
