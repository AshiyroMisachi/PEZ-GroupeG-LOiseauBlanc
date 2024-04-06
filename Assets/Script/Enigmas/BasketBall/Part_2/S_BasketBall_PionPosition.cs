using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BasketBall_PionPosition : MonoBehaviour
{
    [SerializeField]
    private S_Interractible_BasketTerrain basketTerrain;
    [SerializeField]
    private int number;


    public void OnMouseDown()
    {
        if (!basketTerrain.GetIsActive())
        {
            return;
        }
        
        basketTerrain.PlacePion(transform, number);
    }
}