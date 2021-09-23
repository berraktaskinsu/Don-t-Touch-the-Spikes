using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Transform[] spikes;
    private LevelHandler levelHandler;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelHandler = GetComponent<LevelHandler>();
        spikes = GameObject.FindGameObjectWithTag("Spikes").GetComponentsInChildren<Transform>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Wall":
                {
                    levelHandler.Increment();

                    GetComponent<MovePlayer>().speed *= -1;
                    spriteRenderer.flipX = !spriteRenderer.flipX;

                    foreach (Transform spike in spikes)
                    {
                        if (spike != spikes[0])
                        {
                            MoveSpike mover = spike.gameObject.GetComponent<MoveSpike>();
                            if (mover.isVisible)
                            {
                                mover.currentMovement = EMovement.Movement.Hide;
                            }
                        }
                    }

                    int indexOffset = 1;
                    if (GetComponent<MovePlayer>().speed > 0)
                    {
                        // Spiky will move right
                        indexOffset += 16;
                    }
                    foreach (int index in KRandomIndices(levelHandler.numSpikes))
                    {
                        GameObject spike = spikes[index + indexOffset].gameObject;
                        spike.GetComponent<MoveSpike>().currentMovement = EMovement.Movement.Show;
                    }
                    break;
                }
            case "Spike":
                {
                    Destroy(this);
                    Destroy(GetComponent<MovePlayer>());
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

    private int[] KRandomIndices(int k)
    {
        int[] selectedIndices = new int[k];
        for (int i = 0; i < k;)
        {
            int number = Random.Range(0, 15);
            bool isDuplicate = false;
            foreach (int index in selectedIndices)
            {
                if (index == number)
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                selectedIndices[i] = number;
                i++;
            }
        }
        return selectedIndices;
    }
}
