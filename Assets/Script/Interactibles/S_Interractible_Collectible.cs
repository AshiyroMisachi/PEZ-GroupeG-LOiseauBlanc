using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class S_Interractible_Collectible : Interractibles
{
    public override void Interraction()
    {
        Debug.Log("Default Interraction");
    }
}
