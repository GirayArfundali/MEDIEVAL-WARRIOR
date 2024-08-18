using UnityEngine;

public class hareket : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public float jumpForce = 5f; // Zýplama gücü
    public int maxJumpCount = 2; // Maksimum zýplama sayýsý

    private Rigidbody2D rb;
    private Animator animator;
    private int jumpCount = 0;
    private bool isRunning = false;
    private bool isAttacking = false;
    private bool isJumping = false;
    private bool isGrounded = false;
    private karakterhealth healthScript;

    public Transform attackPoint; // Saldýrý yapýlacak nokta
    public float attackRange = 0.5f; // Saldýrý menzili
    public LayerMask enemyLayer; // Düþman katmaný
    public int attackDamage = 10; // Saldýrý hasarý
    public float attackDelay = 0.5f; // Saldýrý gecikme süresi

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthScript = GetComponent<karakterhealth>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < maxJumpCount && (isGrounded || isRunning))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount++;
                animator.SetTrigger("Jump");
                isJumping = true;
                isGrounded = false;
            }
            else if (jumpCount == maxJumpCount - 1 && !isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount++;
                animator.SetTrigger("Jump");
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !isAttacking)
        {
            Attack();
        }

        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        isRunning = Mathf.Abs(rb.velocity.x) > 0 && !isJumping && !isAttacking;
        animator.SetBool("isRunning", isRunning);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin") && !isGrounded)
        {
            jumpCount = 0;
            animator.ResetTrigger("Jump");
            isJumping = false;
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Düþman") && !isAttacking)
        {
            TakeDamage(collision.gameObject, attackDamage);
        }
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("Attack");
            Invoke("PerformAttack", attackDelay);
        }
    }

    private void PerformAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
            }
        }

        isAttacking = false;
    }

    private void TakeDamage(GameObject enemyObject, int damage)
    {
        Enemy enemy = enemyObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        healthScript.UpdateHealthUI();

        if (enemy != null && enemy.IsDead())
        {
            animator.SetBool("Death", true);
            Destroy(enemyObject);
        }

        healthScript.TakeDamage(damage);
        healthScript.UpdateHealthUI();

        if (healthScript.GetCurrentHealth() <= 0)
        {
            animator.SetTrigger("Death");
            Destroy(gameObject, 7f);
        }
    }
}
