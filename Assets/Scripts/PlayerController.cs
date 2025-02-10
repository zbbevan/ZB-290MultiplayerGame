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
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        jumpInput = playerInput.actions["Jump"].WasPressedThisFrame();
        
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
        if (jumpInput)
        {
            transform.position += Vector3.up * jumpHeight;
        }
    }


}
