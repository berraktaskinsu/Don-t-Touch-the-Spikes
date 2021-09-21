using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] float jumpVelocity = 7f;
    private Rigidbody2D rigidBody;
    private Animator animator;

    void Awake()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        rigidBody.velocity = Vector2.up * jumpVelocity;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.velocity = Vector2.up * jumpVelocity;
            RestartAnimation();
        }
    }

    private void RestartAnimation()
    {
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
