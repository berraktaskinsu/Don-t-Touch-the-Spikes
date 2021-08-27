using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] public float speed = 0.02f;
    [SerializeField] float jumpVelocity = 10f;
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
        transform.Translate(speed, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rigidBody.velocity = Vector2.up * jumpVelocity;
            float currentTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (currentTime >= 1f)
            {
                animator.Play("Jump", -1, 0f);
                return;
            }
            int currentFrame = (int)Mathf.Ceil((currentTime * 100) / 11);
            Debug.Log(currentTime + " " + currentFrame);
            int nextFrame = currentFrame - 1;
            if (currentFrame > 6)
            {
                // Restart from equivalent frame
                nextFrame = 11 - currentFrame + 1;
                Debug.Log(currentFrame + " " + nextFrame);

            }
            animator.Play("Jump", -1, (nextFrame * 11f) / 100f);

        }
    }
}
