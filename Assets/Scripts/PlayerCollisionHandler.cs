using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMover playerMover;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMover = GetComponent<PlayerMover>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                {
                    EventSystem.WallHitArgs wallHitArgs = new EventSystem.WallHitArgs(playerMover.speed > 0);
                    EventSystem.OnWallHit(wallHitArgs);
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                    break;
                }
            case "Spike":
                {
                    Destroy(this);
                    Destroy(playerMover);
                    Destroy(gameObject, 1);
                    break;
                }
            case "Candy":
                {
                    break;
                }
            default:
                break;
        }
    }
}
