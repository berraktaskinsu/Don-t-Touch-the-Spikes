using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    private int level = 0;
    public int numSpikes = 0;
    public Text levelText;

    public void Increment()
    {
        level++;
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
