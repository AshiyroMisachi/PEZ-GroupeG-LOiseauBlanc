using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerInterract : MonoBehaviour
{
    [SerializeField]
    //Reference to the camera attach to the player, is used for parenting
    private Transform playerCamera;

    [SerializeField]
    //Range the player can interract
    private float interractRange;

    [SerializeField]
    //Reference to the current object in hand
    private S_Interractible_Collectible objectInHand;
    [SerializeField]
    //Position where the objectInHand will be, it's a local position from the Player
    private Vector3 inHandPosition;


    // Update is called once per frame
    void Update()
    {
        CheckInterractible();
        if (objectInHand != null)
        {
            //Drop the object in hand if pressed
            //if (Input.GetButtonDown("Cancel"))
            if (Input.GetKeyDown(KeyCode.P))
            {
                DropObjectInHand();
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                objectInHand.Interraction();
            }
        }
    }

    //Return the current Object in hand
    public S_Interractible_Collectible GetObjectInHand()
    {
        return objectInHand;
    }

    //Set the current Object in Hand
    public void SetObjectInHand(S_Interractible_Collectible collectible)
    {
        objectInHand = collectible;
        //Give a parent for following the player
        collectible.transform.parent = playerCamera.transform;
        //Adjust the position, to be see on the camera
        collectible.transform.localPosition = inHandPosition;
        //Unable gravity of the object
        collectible.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //Set is rotation to zero
        collectible.transform.eulerAngles = Vector3.zero;
    }

    //Drop to the ground the current object in hand
    private void DropObjectInHand()
    {
        //The object is not a child of the player
        objectInHand.transform.parent = null;
        //Able his gravity to fell to the ground
        objectInHand.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //Set the object in hand to null
        objectInHand = null;
    }

    //Check if the player click on a Interractible
    private void CheckInterractible()
    {
        //If left click pressed
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out var info, interractRange))
        {
            if (info.transform.TryGetComponent<S_Interractible_Collectible>(out var collectible))
            {
                //If no object in hand, set the item in hand
                if (objectInHand == null)
                {
                    SetObjectInHand(collectible);
                    return;
                }
                //Else, drop the current object in hand, and set to the new
                DropObjectInHand();
                SetObjectInHand(collectible);
            }
        }
    }
}
