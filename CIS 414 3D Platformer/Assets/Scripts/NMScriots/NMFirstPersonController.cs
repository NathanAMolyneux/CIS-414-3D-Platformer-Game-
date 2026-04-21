using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class NMFirstPersonController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float highJumpForce = 9f;

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

    private NMIMovementStrategy currentMovementStrategy;
    private NMIJumpStrategy currentJumpStrategy;

    private NMIMovementStrategy normalMovementStrategy;
    private NMIMovementStrategy sprintMovementStrategy;

    private NMIJumpStrategy normalJumpStrategy;
    private NMIJumpStrategy highJumpStrategy;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        normalMovementStrategy = new NMNormalMovementStrategy(moveSpeed);
        sprintMovementStrategy = new NMFastMovementStrategy(sprintSpeed);

        normalJumpStrategy = new NMNormalJumpStrategy(jumpForce);
        highJumpStrategy = new NMSuperJumpStrategy(highJumpForce);

        currentMovementStrategy = normalMovementStrategy;
        currentJumpStrategy = normalJumpStrategy;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        HandleInput();
        HandleMouseLook();
        CheckGround();
        UpdateMovementStrategy();

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
    }

    private void HandleInput()
    {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputZ = Input.GetAxis("Vertical");
    }

    private void UpdateMovementStrategy()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentMovementStrategy = sprintMovementStrategy;
        }
        else
        {
            currentMovementStrategy = normalMovementStrategy;
        }
    }

    private void Move()
    {
        Vector3 moveDirection = (transform.forward * moveInputZ + transform.right * moveInputX).normalized;

        float currentSpeed = currentMovementStrategy.GetMoveSpeed();

        Vector3 newVelocity = moveDirection * currentSpeed;
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * currentJumpStrategy.GetJumpForce(), ForceMode.Impulse);
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

    public void SetNormalJump()
    {
        currentJumpStrategy = normalJumpStrategy;
    }

    public void SetHighJump()
    {
        currentJumpStrategy = highJumpStrategy;
    }

    private Coroutine jumpPowerupCoroutine;

    public void ActivateSuperJump(float duration)
    {
        if (jumpPowerupCoroutine != null)
        {
            StopCoroutine(jumpPowerupCoroutine);
        }

        jumpPowerupCoroutine = StartCoroutine(SuperJumpRoutine(duration));
    }

    private IEnumerator SuperJumpRoutine(float duration)
    {
        currentJumpStrategy = highJumpStrategy;

        yield return new WaitForSeconds(duration);

        currentJumpStrategy = normalJumpStrategy;
        jumpPowerupCoroutine = null;
    }
}