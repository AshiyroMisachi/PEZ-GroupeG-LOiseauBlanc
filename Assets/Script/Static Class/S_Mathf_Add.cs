using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class S_Mathf_Add
{
    public static int LoopClamp(this int actual,int newValue, int min, int max)
    {
        actual = newValue;

        if (actual < min)
        {
            actual = max;
            return actual;
        }

        if (actual > max)
        {
            actual = min;
            return actual;
        }

        return actual;
    }
}
