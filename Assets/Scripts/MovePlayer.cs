using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] public float speed = 0.02f;
    [SerializeField] float jumpVelocity = 2f;
    private Rigidbody2D rigidBody;

    void Awake()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
    }

    void Start() 
    {
        rigidBody.velocity = Vector2.up * jumpVelocity;
    }

    void Update()
    {
        transform.Translate(speed, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidBody.velocity = Vector2.up * jumpVelocity;
        }
    }
}
