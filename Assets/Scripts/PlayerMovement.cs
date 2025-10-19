using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Ground Check")] public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    [SerializeField] private Renderer rend;
    public Color normalColor = Color.white; // Колір на землі
    public Color jumpColor = Color.red; // Колір під час стрибка

    [SerializeField] private Rigidbody rb;
    [SerializeField] private InputActionAsset playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveInput;
    private bool isGrounded;

    private void Awake()
    {
        // Отримуємо дії за іменем в inputActionAsset
        moveAction = playerInput.FindAction("Move");
        jumpAction = playerInput.FindAction("Jump");

        if (moveAction == null) Debug.LogError("Move action not found in PlayerInput.actions");
        if (jumpAction == null) Debug.LogError("Jump action not found in PlayerInput.actions");
        // Опціонально підписуємось на подію натискання, щоб точно впіймати jump
        jumpAction.performed += ctx => TryJump();
    }

    private void OnEnable()
    {
        moveAction?.Enable();
        jumpAction?.Enable();
    }

    private void OnDisable()
    {
        moveAction?.Disable();
        jumpAction?.Disable();
    }

    private void Update()
    {
        if (moveAction != null)
            moveInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayer);
        // change color 
        if (isGrounded)
        {
            rend.material.color = normalColor;
        }
        else
        {
            rend.material.color = jumpColor;
        }

        // Рух вліво/вправо по осі X
        Vector3 v = rb.linearVelocity;
        v.x = moveInput.x * moveSpeed;
        rb.linearVelocity = new Vector3(v.x, rb.linearVelocity.y, 0f);
    }

    private void TryJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}