using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AstronautFirstPersonController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Mouse Look")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private float maxLookAngle = 80f;

    [Header("Ground Check")]
    [SerializeField] private float groundCheckDistance = 1.5f;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private bool anomalyActive = false;

    private Rigidbody rb;
    private float verticalLookRotation;
    private bool isGrounded;

    private float moveInputX;
    private float moveInputZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleInput();
        HandleMouseLook();
        CheckGround();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    public void SetAnomalyState(bool state)
    {
        anomalyActive = state;
    }

    private void FixedUpdate()
    {
        if (!anomalyActive)
        {
            Move();
        }

        rb.angularVelocity = Vector3.zero;
    }

    private void HandleInput()
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputZ = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        Vector3 moveDirection = (transform.forward * moveInputZ + transform.right * moveInputX).normalized;

        Vector3 newVelocity = moveDirection * moveSpeed;
        newVelocity.y = rb.velocity.y; // keep gravity/jump

        rb.velocity = newVelocity;
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -maxLookAngle, maxLookAngle);

        if (cameraHolder != null)
        {
            cameraHolder.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}