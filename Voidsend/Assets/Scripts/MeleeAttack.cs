using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public Transform enemyPos;
    private float enemyDistance;
    private int enemyLayer; // LayerMask to specify which layers are considered enemies
    private int playerLayer; // LayerMask to specify which layers are considered enemies


    [Header("Attack Settings")]
    public GameObject hitBox;
    public float attackRadius = 0.5f;
    public float attackCooldown = 0.5f;
    public float attackDuration = 0.2f; // Duration the hitbox stays active

    private float nextAttackTime = 0f;
    private CircleCollider2D attackCollider;

    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        playerLayer = LayerMask.NameToLayer("Player");

        // Ensure attackPoint has a CircleCollider2D set as trigger
        attackCollider = hitBox.GetComponent<CircleCollider2D>();
        if (attackCollider == null)
        {
            attackCollider = hitBox.AddComponent<CircleCollider2D>();
        }
        attackCollider.isTrigger = true;
        attackCollider.radius = attackRadius;
        attackCollider.enabled = false;

        enemyDistance = Vector2.Distance(transform.position, enemyPos.position);
    }

    void Update()
    {
        enemyDistance = Vector2.Distance(transform.position, enemyPos.position);

        if (Input.GetAxis("Attack") != 0f && Time.time >= nextAttackTime)
        {
            Debug.Log("Attack initiated");

            if (enemyDistance <= 2.0f && enemyDistance >= 1.0f) 
            {
                Debug.Log("Sweetspot hit!");
                StartCoroutine(IntangibleCoroutine(1f));
                this.GetComponentInParent<PlayerMovement>().Dash();
            }

            StartCoroutine(AttackCoroutine());
        }
    }

    void FixedUpdate()
    {
    }

    private System.Collections.IEnumerator IntangibleCoroutine(float duration)
    {
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, true);
        Debug.Log("Player is now intangible for " + duration + " seconds.");
        Debug.Log("EnemyLayer: " + enemyLayer + ", PlayerLayer: " + playerLayer);
        yield return new WaitForSeconds(duration);
        Physics2D.IgnoreLayerCollision(playerLayer, enemyLayer, false);
        Debug.Log("Player is now tangible again.");
    }

    private System.Collections.IEnumerator AttackCoroutine()
    {
        nextAttackTime = Time.time + attackCooldown;
        attackCollider.enabled = true;
        yield return new WaitForSeconds(attackDuration);
        attackCollider.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (hitBox != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hitBox.transform.position, attackRadius);
        }
    }
}
