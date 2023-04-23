using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 6f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        // Add any additional logic here, like playing a death animation or sound effect
        Destroy(gameObject);
    }
}
