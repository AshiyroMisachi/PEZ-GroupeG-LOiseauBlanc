using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ICollectible_Heart : S_Interractible_Collectible
{
            
    // z -> 90 ou -90 + x -90
    
    // x -90 y 90 z 180
    //-90,180,90
    //
    //x tj égal -90 ou 270
    //y-90 = z
    //OU
    //y = z-90

    private S_PlayerManager playerManager;
    private S_PlayerInterract playerInterract;
    private Transform rotationObjectInHand;

    [SerializeField]
    private GameObject referenceRotaHeart;
    void Start()
    {
        playerManager = S_ManagerManager.GetManager<S_PlayerManager>();
        playerInterract = playerManager.GetPlayer().GetComponent<S_PlayerInterract>();

        
    }

    public override void InterractionInspection()
    {
        rotationObjectInHand = playerInterract.GetObjectPosition();

        Debug.Log("x = " + rotationObjectInHand.transform.localEulerAngles.x);
        Debug.Log("y = " + rotationObjectInHand.transform.localEulerAngles.y);
        Debug.Log("z = " + rotationObjectInHand.transform.localEulerAngles.z);
        var x = rotationObjectInHand.transform.localEulerAngles.x;
        var y = rotationObjectInHand.transform.localEulerAngles.y;
        var z = rotationObjectInHand.transform.localEulerAngles.z;

        if ((x <= -85 && x>= -95) || (x >= 265 && x <= 275))
        {
            if ((y % 90 == 0) && (z %90 == 0)) 
            {
                if ((y + 90 == z ) || (y == z + 90))
                {
                    Debug.Log("inY");

                }


            }
        }


    }




}
