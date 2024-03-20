using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ICollectible_BaseObject : S_Interractible_Collectible
{
    public override void Interraction()
    {
        Debug.Log("Use item in hand");
    }
}
