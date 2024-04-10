using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ICollectible_Heart : S_Interractible_Collectible
{





    public S_PlayerManager playerManager;
    public S_PlayerInterract playerInterract;
    void Start()
    {
        playerManager = S_ManagerManager.GetManager<S_PlayerManager>();
        playerInterract = playerManager.GetPlayer().GetComponent<S_PlayerInterract>();
        
    }

    public override void InterractionInspection()
    {

        if (true)
        {
            Debug.Log("bonne position !");
            //set pos jeur
            //set rota keur
            //mettre keur kinematic true
        }



    }




}
