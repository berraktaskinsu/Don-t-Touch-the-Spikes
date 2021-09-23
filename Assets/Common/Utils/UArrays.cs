using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UArrays
{
    public static int[] KRandomIndices(int k)
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
