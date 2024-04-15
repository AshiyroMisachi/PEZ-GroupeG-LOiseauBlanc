using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interractible_AlonePuppet : Interractibles
{
    [SerializeField]
    private GameObject puppet, savedPuppet;

    private bool firstInterract;
    [SerializeField]
    private SO_Dialogue firstInterractDialogue, finishDialogue;

    public override void Interraction()
    {
        var playerInterract = S_ManagerManager.GetManager<S_PlayerManager>().GetPlayer().GetComponent<S_PlayerInterract>();

        if (playerInterract.GetObjectInHand() != null && puppet != null && playerInterract.GetObjectInHand().gameObject == puppet)
        {
            savedPuppet.SetActive(true);
            playerInterract.DestroyObjectInHand();
            S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(finishDialogue);

            //UNLOCK THIS FOR TRAIN
            S_ManagerManager.GetManager<S_Train>().isEnigmaCompleted(2);

            return;
        }

        if (!firstInterract)
        {
            firstInterract = true;
            S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(firstInterractDialogue);
        }
    }
}