using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class EnemyAI : MonoBehaviour
    {
        private Rigidbody2D rb;
        private AnimationSwitch animationSwitch;
        public float moveSpeed = 5f;
        public float stoppingDistance = 1f;
        public float detectionRange = 5f;
        public float attackRange = 2f;
        public Transform target;
        private bool playerDetected = false;
        private bool isAttacking = false;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animationSwitch = GetComponent<AnimationSwitch>();

            if (animationSwitch == null)
            {
                animationSwitch = gameObject.AddComponent<AnimationSwitch>();
            }

            if (animationSwitch != null)
            {
                animationSwitch.AnimateIDLE();
            }
            else
            {
                Debug.LogError("AnimationSwitch component not found or could not be added!");
            }
        }

        private void Update()
        {
            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (distanceToTarget <= detectionRange)
            {
                playerDetected = true;
            }
            else
            {
                playerDetected = false;
            }

            if (playerDetected)
            {
                if (distanceToTarget > stoppingDistance)
                {
                    Vector2 direction = (target.position - transform.position).normalized;
                    rb.velocity = direction * moveSpeed;

                    if (distanceToTarget > attackRange)
                    {
                        rb.velocity = direction * moveSpeed;
                        animationSwitch.AnimateRun();
                        isAttacking = false;
                    }
                    else
                    {
                        rb.velocity = Vector2.zero;
                        if (!isAttacking)
                        {
                            StartCoroutine(PerformAttack());
                        }
                    }
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    animationSwitch.AnimateIDLE();
                }
            }
            else
            {
                // Burada düþmanýn baðýmsýz hareketini saðlayacak kodu ekleyebilirsiniz.
                // Örneðin, belirli bir yol izlemesi, dolaþmasý veya rastgele hareket etmesi gibi.
                rb.velocity = Vector2.zero;
                animationSwitch.AnimateIDLE();
            }
        }

        private IEnumerator PerformAttack()
        {
            isAttacking = true;
            animationSwitch.AnimateAttack();

            yield return new WaitForSeconds(animationSwitch.GetAttackAnimationLength());

            // Saldýrý animasyonu tamamlandýktan sonra tekrar harekete devam edebilirsiniz
            isAttacking = false;
        }
    }
}