using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        EventSystem.AnimateJump += RestartAnimation;
    }

    private void RestartAnimation(EventSystem.JumpArgs args)
    {
        // Only works for symmetric animations !!
        float currentTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (currentTime >= 1f)
        {
            animator.Play("Jump", -1, 0f);
            return;
        }
        int currentFrame = (int)Mathf.Ceil((currentTime * 100) / 11);

        int nextFrame = currentFrame - 1;
        if (currentFrame > 6)
        {
            // Restart from equivalent frame
            nextFrame = 11 - currentFrame + 1;

        }
        animator.Play("Jump", -1, (nextFrame * 11f) / 100f);
    }
}
