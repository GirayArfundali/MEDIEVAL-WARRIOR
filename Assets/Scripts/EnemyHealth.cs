using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maksimum can
    private int currentHealth; // Mevcut can

    private void Start()
    {
        currentHealth = maxHealth; // Baþlangýçta caný maksimuma ayarla
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Hasarý düþmandan çýkar

        if (currentHealth <= 0)
        {
            Die(); // Can sýfýr veya daha azsa ölümü tetikle
        }
    }

    private void Die()
    {
        // Ölüm iþlemleri burada gerçekleþtirilebilir
        Destroy(gameObject);
    }
}
