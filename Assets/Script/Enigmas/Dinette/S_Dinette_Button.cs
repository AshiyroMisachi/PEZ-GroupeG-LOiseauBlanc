using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Dinette_Button : MonoBehaviour
{
    [SerializeField]
    private int actualNumbers;
    [SerializeField]
    private float buttonRotation;

    public int GetActualNumbers()
    {
        return actualNumbers;
    }

    public void OnMouseDown()
    {
        actualNumbers = actualNumbers.LoopClamp(actualNumbers + 1, 0, 12);
        transform.Rotate(-buttonRotation, 0, 0);
    }
}