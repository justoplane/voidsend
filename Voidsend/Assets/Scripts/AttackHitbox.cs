using UnityEngine;

public class AttackHitbox : MonoBehaviour
{

    public LayerMask enemyLayer; // LayerMask to specify which layers are considered enemies

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Uses bitmask to check if the other collider is on the enemy layer
        if (((1 << other.gameObject.layer) & enemyLayer) != 0)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(); // Adjust as needed
            }
        }
    }
}
