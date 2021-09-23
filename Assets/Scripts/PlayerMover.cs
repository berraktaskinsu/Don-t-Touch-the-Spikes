using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private bool isGameStarted = false;
    private float gravityScale;
    private Vector3 nextPosition;
    private Rigidbody2D rigidBody;

    [SerializeField] public float idleSpeed = 2f;
    [SerializeField] public float jumpVelocity = 7f;
    [SerializeField] public Transform posUp, posDown;
    [SerializeField] public float speed = 5f;

    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
        gravityScale = rigidBody.gravityScale;
        rigidBody.gravityScale = 0;
        nextPosition = posUp.position;

        EventSystem.NextLevel += ChangeDirection;
        EventSystem.Jump += Jump;
    }
    void Update()
    {
        if (isGameStarted)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            if (transform.position == posUp.position)
            {
                EventSystem.JumpArgs jumpArgs = new EventSystem.JumpArgs();
                EventSystem.OnAnimateJump(jumpArgs);
                nextPosition = posDown.position;
            }
            else if (transform.position == posDown.position)
            {
                nextPosition = posUp.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, idleSpeed * Time.deltaTime);
        }
    }
    private void ChangeDirection(EventSystem.WallHitArgs wallHitArgs)
    {
        speed *= -1;
    }
    private void Jump(EventSystem.JumpArgs jumpArgs)
    {
        if (!isGameStarted)
        {
            isGameStarted = true;
            rigidBody.gravityScale = gravityScale;
        }
        rigidBody.velocity = Vector2.up * jumpVelocity;
    }
}
