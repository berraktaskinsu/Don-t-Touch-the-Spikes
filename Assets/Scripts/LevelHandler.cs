using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public int numSpikes = 0;
    public Text levelText;
    private int level = 0;
    void Start()
    {
        EventSystem.BeforeNextLevel += Increment;
    }
    private void Increment(EventSystem.WallHitArgs wallHitArgs)
    {
        level++;
        Debug.Log(level);
        if (level == 1)
        {
            numSpikes = 2;
            levelText.enabled = true;
        }
        else
        {
            numSpikes = 3 + level / 10;
        }
        levelText.text = level.ToString();
    }
}
