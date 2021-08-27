using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                {
                    GetComponent<MovePlayer>().speed *= -1;
                    Debug.Log("Wall");
                    break;
                }
            case "Spike":
                {
                    Destroy(this);
                    Debug.Log("Game Over");
                    Destroy(GetComponent<MovePlayer>());
                    Destroy(gameObject, 5);
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
