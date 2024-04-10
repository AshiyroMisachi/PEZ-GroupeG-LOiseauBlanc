using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class S_PlayerInterract : MonoBehaviour
{
    [SerializeField]
    //Reference to the objectPosition to the player, is used for parenting
    private Transform objectPosition;

    [SerializeField]
    //Reference to the playerCamera, used for a Raycast
    private Transform playerCamera;

    [SerializeField]
    //Range the player can interract
    private float interractRange;

    [SerializeField]
    //Reference to the current object in hand
    private S_Interractible_Collectible objectInHand;
    [SerializeField]
    //Position where the objectInHand will be, it's a local cardNumber from the Player
    private Vector3 inHandPosition;

    [SerializeField]
    private Vector3 inInspectionPosition;

    [SerializeField]
    private float inspectSpeed, inspectZoomSpeed;

    // Update is called once per frame
    void Update()
    {
        var playerManager = S_ManagerManager.GetManager<S_PlayerManager>();

        if (playerManager.GetPlayerState() == PlayerState.Exploration)
        {
            CheckInterractible();
        }

        if (objectInHand != null && playerManager.GetPlayerState() == PlayerState.Exploration)
        {
            //Drop the object in hand if pressed
            //if (Input.GetButtonDown("Cancel"))
            if (Input.GetKeyDown(KeyCode.P))
            {
                DropObjectInHand();
                return;
            }

            //Use Object in Hand
            if (Input.GetKeyDown(KeyCode.E))
            {
                objectInHand.Interraction();
                return;
            }

        }

        if (playerManager.GetPlayerState() == PlayerState.Inspect)
        {
            InspectionInput();
            //Use Object in Hand
            if (Input.GetKeyDown(KeyCode.E))
            {
                objectInHand.InterractionInspection();
                return;
            }
        }

        //SetupInspect Object in Hand
        if (Input.GetMouseButtonDown(1) && objectInHand != null)
        {
            SetupInspect();
            return;
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
        collectible.transform.parent = objectPosition.transform;
        //Adjust the cardNumber, to be see on the camera
        objectPosition.transform.localPosition = inHandPosition;
        collectible.transform.localPosition = Vector3.zero;
        //Unable gravity of the object
        collectible.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //Set is rotation to zero
        collectible.transform.localEulerAngles = Vector3.zero;
    }

    //Drop to the ground the current object in hand
    public  void DropObjectInHand()
    {
        //The object is not a child of the player
        objectInHand.transform.parent = null;
        //Able his gravity to fell to the ground
        objectInHand.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //Set the object in hand to null
        objectInHand = null;
    }

    public void DestroyObjectInHand()
    {
        Destroy(objectInHand.gameObject);
        objectInHand = null;
    }

    //Check if the player click on a Interractible
    private void CheckInterractible()
    {
        //If left click pressed
        if (Input.GetButtonDown("Fire1") && Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out var info, interractRange))
        {
            //If the raycast collide a Collectible Object
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
                return;
            }

            //If the raycast collide a Interractible
            if (info.transform.TryGetComponent<Interractibles>(out var interactible))
            {
                interactible.Interraction();
                return;
            }
        }
    }

    private void SetupInspect()
    {
        //Setup Inspect Mode
        var playerManager = S_ManagerManager.GetManager<S_PlayerManager>();
        if (playerManager.GetPlayerState() != PlayerState.Inspect)
        {
            playerManager.SetPlayerState(PlayerState.Inspect);
            objectPosition.transform.localPosition = inInspectionPosition;
            return;
        }
        //Leave Inspect Mode
        playerManager.SetPlayerState(PlayerState.Exploration);
        objectPosition.transform.localPosition = inHandPosition;
        objectPosition.transform.localEulerAngles = Vector3.zero;
        playerCamera.GetComponent<Camera>().fieldOfView = 60;
    }

    private void InspectionInput()
    {
        //Object Rotation 
        //Stock Axis value
        //Put * Time.deltaTime bug all the rotation and zoom here
        float x = Input.GetAxis("Horizontal") * inspectSpeed;
        float z = Input.GetAxis("Vertical") * inspectSpeed;
        float zoom = Input.GetAxis("Mouse ScrollWheel") * inspectZoomSpeed;

        objectPosition.transform.Rotate(x, 0, z , Space.Self);
        playerCamera.GetComponent<Camera>().fieldOfView = Mathf.Clamp(playerCamera.GetComponent<Camera>().fieldOfView + zoom, 30, 60);
    }
}