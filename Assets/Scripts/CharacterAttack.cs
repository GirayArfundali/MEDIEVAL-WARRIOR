using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public int attackDamage = 10;

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(attackDamage);
        }
    }
}
