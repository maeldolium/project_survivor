using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
