using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10; // Hasar miktarý

    private void DealDamageToCharacter()
    {
        // Karaktere hasar verme iþlemini gerçekleþtir
        karakterhealth healthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<karakterhealth>();
        healthScript.TakeDamage(damageAmount);
        healthScript.UpdateHealthUI();
    }

    // Bu metot, düþmanýn saldýrý animasyonunda bir event olarak çaðrýlacak
    public void AttackAnimationEvent()
    {
        // Karaktere hasar verme iþlemini gerçekleþtir
        DealDamageToCharacter();
    }
}
