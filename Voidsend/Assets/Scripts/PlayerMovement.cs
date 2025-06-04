using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Transform enemyPos;
    private float enemyDistance;

    [Header("Movement Settings")]
    public float baseSpeed = 5f;
    public float momentumDecay = 5f; // How fast momentum fades
    public float maxMomentum = 10f;
    public float slowCooldown = 2f; // Cooldown for slow motion activation

    [Header("Dash Settings")]
    public float dashForce = 20f;
    public float dashCooldown = 0.5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 momentum = Vector2.zero;
    private float lastDashTime;
    private float lastSlowTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyDistance = Vector2.Distance(transform.position, enemyPos.position);
    }

    void Update()
    {
        enemyDistance = Vector2.Distance(transform.position, enemyPos.position);

        HandleInput();
        if (Input.GetButtonDown("Dash") && Time.time - lastDashTime > dashCooldown)
        {
            Debug.Log("Dash initiated");
            Dash();
        }

        if (Input.GetAxis("Slow") != 0f && Time.time - lastSlowTime > dashCooldown)
        {
            // Slow down the player
            StartCoroutine(SlowMotionTimer(1f)); // Adjust duration as needed
            Debug.Log("Slow motion activated");
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (enemyDistance <= 2.0f && enemyDistance >= 1.0f)
        {
            sr.color = Color.red; // Change to red        }   
        }
        else
        {
            sr.color = Color.blue;
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

    public void Dash()
    {
        if (moveInput != Vector2.zero)
        {
            // Add momentum in dash direction
            momentum += moveInput.normalized * dashForce;
            lastDashTime = Time.time;
        }
    }

    IEnumerator SlowMotionTimer(float duration)
    {
        lastSlowTime = Time.time;
        Time.timeScale = 0.5f; // Slow motion effect
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f; // Reset time scale
    }

    public Vector2 GetCurrentVelocity()
    {
        return rb.linearVelocity;
    }
}
