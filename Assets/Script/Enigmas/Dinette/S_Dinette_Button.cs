using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Dinette_Button : MonoBehaviour
{
    [SerializeField]
    private int actualNumbers;
    [SerializeField]
    private float buttonRotation;

    [SerializeField]
    private S_Interractible_Dinette dinette;
    public int GetActualNumbers()
    {
        return actualNumbers;
    }

    public void OnMouseDown()
    {
        if (!dinette.GetIsActive())
        {
            return;
        }

        actualNumbers = actualNumbers.LoopClamp(actualNumbers + 1, 0, 11);
        transform.Rotate(-buttonRotation, 0, 0);
    }
}