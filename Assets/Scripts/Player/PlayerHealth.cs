using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10f;
    private float currentHealth;

    public AudioClip damageSound;
    private AudioSource audioSource;

    public float damageCooldown = 1.0f;
    private float nextDamageTime;

    private void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            gameObject.AddComponent<AudioSource>();
            audioSource = GetComponent<AudioSource>();
        }
        nextDamageTime = Time.time;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (damageSound != null && Time.time >= nextDamageTime)
        {
            audioSource.PlayOneShot(damageSound);
        }

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
