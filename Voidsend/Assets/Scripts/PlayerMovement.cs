using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float baseSpeed = 5f;
    public float momentumDecay = 5f; // How fast momentum fades
    public float maxMomentum = 10f;

    [Header("Dash Settings")]
    public float dashForce = 20f;
    public float dashCooldown = 0.5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 momentum = Vector2.zero;
    private float lastDashTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastDashTime > dashCooldown)
        {
            Dash();
        }
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    void HandleInput()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void ApplyMovement()
    {
        // Base movement input
        Vector2 moveVelocity = moveInput * baseSpeed;

        // Apply momentum and decay over time
        momentum = Vector2.Lerp(momentum, Vector2.zero, momentumDecay * Time.fixedDeltaTime);

        // Cap momentum
        if (momentum.magnitude > maxMomentum)
            momentum = momentum.normalized * maxMomentum;

        // Final velocity
        Vector2 finalVelocity = moveVelocity + momentum;

        rb.linearVelocity = finalVelocity;
    }

    void Dash()
    {
        if (moveInput != Vector2.zero)
        {
            // Add momentum in dash direction
            momentum += moveInput.normalized * dashForce;
            lastDashTime = Time.time;
        }
    }

    // Optional: call this from wall-jump, grapple, or kill-based reward system
    public void AddMomentum(Vector2 direction, float force)
    {
        momentum += direction.normalized * force;
    }

    public void ResetMomentum()
    {
        momentum = Vector2.zero;
    }

    public Vector2 GetCurrentVelocity()
    {
        return rb.linearVelocity;
    }
}
