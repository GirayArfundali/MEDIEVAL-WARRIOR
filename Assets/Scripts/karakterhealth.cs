using UnityEngine;
using UnityEngine.UI;

public class karakterhealth : MonoBehaviour
{
    public Image healthBar; // UI Image bileþeni
    public Animator animator; // Animator bileþeni
    public float updateSpeed = 5f; // Can çubuðunun güncellenme hýzý
    public float maxHealth = 100f; // Maksimum saðlýk deðeri

    public GameObject restartPanel; // Restart panel GameObject

    private float currentHealth; // Mevcut saðlýk deðeri
    private float targetHealth; // Hedef saðlýk deðeri

    private void Start()
    {
        currentHealth = maxHealth; // Baþlangýçta saðlýk deðerini maksimum saðlýk deðeriyle ayarla
        targetHealth = currentHealth; // Hedef saðlýk deðerini mevcut saðlýk deðeriyle eþitle
        UpdateHealthUI();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Hasarý mevcut saðlýk deðerinden çýkar
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // Saðlýk deðerini 0 ile maksimum saðlýk deðeri arasýnda sýnýrla
        targetHealth = currentHealth; // Hedef saðlýk deðerini güncelle
        UpdateHealthUI();

        // Can deðeri 0 olduðunda karakteri yok et ve restartPanel'i aktifleþtir
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            ActivateRestartPanel();
        }
    }

    private void Update()
    {
        // Eðer hedef saðlýk deðeri mevcut saðlýk deðerinden farklýysa, hedef deðeri güncelle
        if (targetHealth != currentHealth)
        {
            currentHealth = Mathf.MoveTowards(currentHealth, targetHealth, updateSpeed * Time.deltaTime);
            UpdateHealthUI();
        }
    }

    public void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            float fillAmount = currentHealth / maxHealth; // Doluluk oranýný hesapla
            healthBar.fillAmount = fillAmount; // Can çubuðunun doluluk oranýný güncelle
        }
        else
        {
            Debug.LogError("healthBar referansý atanmamýþ! Lütfen healthBar nesnesini atayýn.");
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Düþman"))
        {
            float damageAmount = 10f;
            TakeDamage(damageAmount);

            if (GetCurrentHealth() <= 0)
            {
                // Can sýfýr veya daha az ise karakteri yok etme iþlemi ve restartPanel'i aktifleþtirme
                Destroy(gameObject);
                ActivateRestartPanel();
            }
        }
    }

    private void ActivateRestartPanel()
    {
        if (restartPanel != null)
        {
            restartPanel.SetActive(true); // Activate the restart panel

            // Pause the game when the restart panel is active
            Time.timeScale = 0f;

            // Disable character control to prevent further movement or input
            // Replace "CharacterController" with your character controller component or script name
            CharacterController characterController = GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false;
            }
            else
            {
                Debug.LogError("CharacterController component not found! Make sure it is attached to the character.");
            }
        }
        else
        {
            Debug.LogError("restartPanel referansý atanmamýþ! Lütfen restartPanel nesnesini atayýn.");
        }
    }

}
