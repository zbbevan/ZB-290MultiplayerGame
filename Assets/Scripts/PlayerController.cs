using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int playerID = 1;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    private Vector2 moveInput;
    private bool jumpInput;
    private PlayerInput playerInput;
    private Rigidbody rb;

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

        
        
        if (jumpInput)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
       rb.AddRelativeForce(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);
    }


}
