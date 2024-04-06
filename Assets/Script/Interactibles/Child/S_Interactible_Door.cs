using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interactible_Door : Interractibles
{
    [SerializeField]
    //Reference to the key who open the door
    private GameObject key;
    //Stock if the player already interact with the key on this door
    private bool haveKey = false;

    [SerializeField]
    private Animator animator;
    //Bool who said if door is open or not, false = close, true = open
    private bool state = false;

    public override void Interraction()
    {
        var playerInterract = S_ManagerManager.GetManager<S_PlayerManager>().GetPlayer().GetComponent<S_PlayerInterract>();
        if (playerInterract.GetObjectInHand() != null && key != null && playerInterract.GetObjectInHand().gameObject == key)
        {
            haveKey = true;
            playerInterract.DestroyObjectInHand();
        }

        if (!haveKey)
        {
            return;
        }

        if (state)
        {
            animator.SetTrigger("Close");
            state = false;
            return;
        }
        animator.SetTrigger("Open");
        state = true;
    }
}
