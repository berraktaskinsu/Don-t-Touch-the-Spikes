using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private Transform[] spikes;
    private LevelHandler levelHandler;
    void Start()
    {
        spikes = gameObject.GetComponentsInChildren<Transform>();
        EventSystem.NextLevel += RefreshSpikes;
        levelHandler = GameObject.FindObjectOfType<LevelHandler>();
    }
    private void RefreshSpikes(EventSystem.WallHitArgs wallHitArgs)
    {
        foreach (Transform spike in spikes)
        {
            if (spike != spikes[0])
            {
                SpikeMover mover = spike.gameObject.GetComponent<SpikeMover>();
                if (mover.isVisible)
                {
                    mover.ChangeMovement(EMovement.Movement.Hide);
                }
            }
        }
        int indexOffset = 1;
        if (!wallHitArgs.isRightWall)
        {
            // Spiky will move right
            indexOffset += 16;
        }
        foreach (int index in UArrays.KRandomIndices(levelHandler.numSpikes))
        {
            SpikeMover spikeMover = spikes[index + indexOffset].gameObject.GetComponent<SpikeMover>();
            spikeMover.ChangeMovement(EMovement.Movement.Show);
        }
    }
}

