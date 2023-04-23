using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemyHealth = collision.collider.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
