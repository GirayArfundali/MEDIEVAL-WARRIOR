using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSwitch : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found!");
        }
    }

    public void AnimateIDLE()
    {
        ResetBools();
        animator.SetBool("idle", true);
    }

    public void AnimateAttack()
    {
        ResetBools();
        animator.SetBool("attack", true);
        Invoke("AddIdle", GetAttackAnimationLength());
    }

    public void AnimateDeath()
    {
        ResetBools();
        animator.SetBool("death", true);
    }

    public void AnimateJump()
    {
        ResetBools();
        animator.SetBool("jump", true);
        Invoke("AddIdle", 0.1f);
    }

    public void AnimateRun()
    {
        ResetBools();
        animator.SetBool("run", true);
    }

    public void AnimateWalk()
    {
        ResetBools();
        animator.SetBool("walk", true);
    }

    private void ResetBools()
    {
        if (animator != null)
        {
            animator.SetBool("idle", false);
            animator.SetBool("attack", false);
            animator.SetBool("death", false);
            animator.SetBool("jump", false);
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
        }
    }

    private void AddIdle()
    {
        animator.SetBool("idle", true);
    }

    public bool IsPlayerDetected()
    {
        // Oyuncu algýlama mantýðý buraya yazýlacak
        // Algýlama sonucuna göre true veya false döndürülebilir
        return false;
    }

    public float GetAttackAnimationLength()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        float attackAnimationLength = 0f;

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "attack") // Saldýrý animasyonunun ismini buraya yazýn
            {
                attackAnimationLength = clip.length;
                break;
            }
        }

        return attackAnimationLength;
    }
}
