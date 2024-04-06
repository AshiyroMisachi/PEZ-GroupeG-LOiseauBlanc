using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_BasketBall_Pion : MonoBehaviour
{
    [SerializeField]
    private S_Interractible_BasketTerrain basketTerrain;

    [SerializeField]
    private int position;
    public int GetPosition()
    {
        return position;
    }

    public void SetPosition(int position)
    {
        this.position = position;
    }

    public void OnMouseDown()
    {
        if (!basketTerrain.GetIsActive())
        {
            return;
        }
        basketTerrain.SetCurrentPion(this);
    }
}