using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10; // Hasar miktar�

    private void DealDamageToCharacter()
    {
        // Karaktere hasar verme i�lemini ger�ekle�tir
        karakterhealth healthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<karakterhealth>();
        healthScript.TakeDamage(damageAmount);
        healthScript.UpdateHealthUI();
    }

    // Bu metot, d��man�n sald�r� animasyonunda bir event olarak �a�r�lacak
    public void AttackAnimationEvent()
    {
        // Karaktere hasar verme i�lemini ger�ekle�tir
        DealDamageToCharacter();
    }
}
