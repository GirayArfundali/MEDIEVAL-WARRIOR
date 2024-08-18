using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int health = 100;
    public Image healthImage; // Health bar image

    private void Start()
    {
        UpdateHealthBar(); // Update the health bar initially
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

        UpdateHealthBar(); // Update the health bar
    }

    private void UpdateHealthBar()
    {
        float normalizedHealth = (float)health / 100f;
        healthImage.fillAmount = normalizedHealth; // Update the fill amount of the health bar image
    }

    private void Die()
    {
        // Enemy death actions go here
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
