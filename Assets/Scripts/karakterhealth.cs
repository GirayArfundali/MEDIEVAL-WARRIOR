using UnityEngine;
using UnityEngine.UI;

public class karakterhealth : MonoBehaviour
{
    public Image healthBar; // UI Image bile�eni
    public Animator animator; // Animator bile�eni
    public float updateSpeed = 5f; // Can �ubu�unun g�ncellenme h�z�
    public float maxHealth = 100f; // Maksimum sa�l�k de�eri

    public GameObject restartPanel; // Restart panel GameObject

    private float currentHealth; // Mevcut sa�l�k de�eri
    private float targetHealth; // Hedef sa�l�k de�eri

    private void Start()
    {
        currentHealth = maxHealth; // Ba�lang��ta sa�l�k de�erini maksimum sa�l�k de�eriyle ayarla
        targetHealth = currentHealth; // Hedef sa�l�k de�erini mevcut sa�l�k de�eriyle e�itle
        UpdateHealthUI();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Hasar� mevcut sa�l�k de�erinden ��kar
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // Sa�l�k de�erini 0 ile maksimum sa�l�k de�eri aras�nda s�n�rla
        targetHealth = currentHealth; // Hedef sa�l�k de�erini g�ncelle
        UpdateHealthUI();

        // Can de�eri 0 oldu�unda karakteri yok et ve restartPanel'i aktifle�tir
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            ActivateRestartPanel();
        }
    }

    private void Update()
    {
        // E�er hedef sa�l�k de�eri mevcut sa�l�k de�erinden farkl�ysa, hedef de�eri g�ncelle
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
            float fillAmount = currentHealth / maxHealth; // Doluluk oran�n� hesapla
            healthBar.fillAmount = fillAmount; // Can �ubu�unun doluluk oran�n� g�ncelle
        }
        else
        {
            Debug.LogError("healthBar referans� atanmam��! L�tfen healthBar nesnesini atay�n.");
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("D��man"))
        {
            float damageAmount = 10f;
            TakeDamage(damageAmount);

            if (GetCurrentHealth() <= 0)
            {
                // Can s�f�r veya daha az ise karakteri yok etme i�lemi ve restartPanel'i aktifle�tirme
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
            Debug.LogError("restartPanel referans� atanmam��! L�tfen restartPanel nesnesini atay�n.");
        }
    }

}
