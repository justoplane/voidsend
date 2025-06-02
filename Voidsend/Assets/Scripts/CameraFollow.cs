using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target; // Player transform

    [Header("Camera Settings")]
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0, 0, -10f); // Keep camera behind the scene

    [Header("Lookahead")]
    public bool enableLookahead = true;
    public float lookaheadDistance = 2f;
    public float lookaheadSmoothing = 5f;

    private Vector3 lookahead = Vector3.zero;
    private Vector3 currentVelocity = Vector3.zero;

    private PlayerMovement playerMovement;

    void Start()
    {
        if (target != null)
        {
            playerMovement = target.GetComponent<PlayerMovement>();
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        if (enableLookahead && playerMovement != null)
        {
            Vector2 velocity = playerMovement.GetCurrentVelocity();
            lookahead = Vector3.Lerp(lookahead, (Vector3)velocity.normalized * lookaheadDistance, Time.deltaTime * lookaheadSmoothing);
            desiredPosition += lookahead;
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;
    }
}
