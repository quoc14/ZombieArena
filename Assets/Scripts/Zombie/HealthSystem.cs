using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject healthBarUI;
    public RectTransform healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBar.localScale = new Vector3(healthPercentage, 1, 1);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
