using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interractible_AlonePuppet : Interractibles
{
    [SerializeField]
    private GameObject puppet, savedPuppet;

    public override void Interraction()
    {
        var playerInterract = S_ManagerManager.GetManager<S_PlayerManager>().GetPlayer().GetComponent<S_PlayerInterract>();

        if (playerInterract.GetObjectInHand() != null && puppet != null && playerInterract.GetObjectInHand().gameObject == puppet)
        {
            savedPuppet.SetActive(true);
            playerInterract.DestroyObjectInHand();

            //UNLOCK THIS FOR TRAIN


            return;
        }
    }
}