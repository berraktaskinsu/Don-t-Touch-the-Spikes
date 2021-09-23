using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveSpike : MonoBehaviour
{
    public EMovement.Movement currentMovement = EMovement.Movement.Idle;
    public bool isVisible = false;
    private PolygonCollider2D spikeCollider;
    private float hiddenX;
    private float visibleX;
    private float speedX; // per frame



    [SerializeField]
    public float duration = 0.1f; // seconds 

    void Start()
    {
        spikeCollider = GetComponent<PolygonCollider2D>();
        if (spikeCollider.enabled)
        {
            spikeCollider.enabled = false;
        }
        hiddenX = transform.localPosition.x;
        visibleX = hiddenX + (transform.localScale.x / 2) * (hiddenX > 0 ? -1 : 1);
        speedX = (visibleX - hiddenX) / duration;
    }

    void Update()
    {
        float currentX = transform.localPosition.x;
        switch (currentMovement)
        {
            case EMovement.Movement.Show:
                {
                    if (currentX == visibleX)
                    {
                        currentMovement = EMovement.Movement.Idle;
                        isVisible = true;
                        break;
                    }
                    if (!spikeCollider.enabled)
                    {
                        spikeCollider.enabled = true;
                    }
                    float deltaX = (hiddenX < 0 ? 1 : -1) * Mathf.Min(Mathf.Abs(speedX * Time.deltaTime), Mathf.Abs(visibleX - currentX));
                    transform.localPosition = transform.localPosition + new Vector3(deltaX, 0, 0);
                    break;
                }
            case EMovement.Movement.Hide:
                {
                    if (currentX == hiddenX)
                    {
                        currentMovement = EMovement.Movement.Idle;
                        isVisible = false;
                        break;
                    }
                    if (spikeCollider.enabled)
                    {
                        spikeCollider.enabled = false;
                    }
                    float deltaX = (hiddenX < 0 ? 1 : -1) * Mathf.Min(Mathf.Abs(speedX * Time.deltaTime), Mathf.Abs(hiddenX - currentX));
                    transform.localPosition = transform.localPosition - new Vector3(deltaX, 0, 0);
                    break;
                }
        }
    }
}
