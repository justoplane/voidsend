using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage() 
    { 
        Debug.Log("Enemy took damage!"); // Log damage taken
        //this.gameObject.SetActive(false); // Deactivate the enemy GameObject
    }
}
