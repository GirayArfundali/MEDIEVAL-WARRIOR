using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maksimum can
    private int currentHealth; // Mevcut can

    private void Start()
    {
        currentHealth = maxHealth; // Ba�lang��ta can� maksimuma ayarla
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Hasar� d��mandan ��kar

        if (currentHealth <= 0)
        {
            Die(); // Can s�f�r veya daha azsa �l�m� tetikle
        }
    }

    private void Die()
    {
        // �l�m i�lemleri burada ger�ekle�tirilebilir
        Destroy(gameObject);
    }
}
