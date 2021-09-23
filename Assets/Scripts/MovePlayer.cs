using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private bool isGameStarted = false;
    private float gravityScale;
    private Vector3 nextPosition;


    [SerializeField]
    public float speed = 5f;
    public float idleSpeed = 2f;
    public float jumpVelocity = 7f;
    public Transform posUp, posDown;

    void Awake()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
        gravityScale = rigidBody.gravityScale;
        rigidBody.gravityScale = 0;
        animator = gameObject.GetComponent<Animator>();
        nextPosition = posUp.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                rigidBody.gravityScale = gravityScale;
            }
            Jump();
        }

        if (isGameStarted)
        {
            Move();
        }
        else
        {
            Float();
        }
    }

    private void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void Jump()
    {
        rigidBody.velocity = Vector2.up * jumpVelocity;
        RestartAnimation();
    }

    private void Float()
    {
        if (transform.position == posUp.position)
        {
            RestartAnimation();
            nextPosition = posDown.position;
        }
        else if (transform.position == posDown.position)
        {
            nextPosition = posUp.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, idleSpeed * Time.deltaTime);
    }

    private void RestartAnimation()
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
