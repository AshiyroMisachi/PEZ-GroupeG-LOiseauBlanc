using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_CheckRotationheart : Interractibles
{


    [SerializeField]
    private GameObject heartItem, heartObject;
    private bool isActive;
    [SerializeField]
    private Camera puzzleCamera; 
    [SerializeField]
    private float inspectSpeed = 1, inspectZoomSpeed = 0;



    public void Update()
    {

        //to quit the puzzle
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetupPuzzle();
        }


        if (!isActive)
        {
            return;
        }



        if (heartObject.activeInHierarchy)
        {
            Debug.Log("test");

            //ajout rota

            //code test bonne rota

            float x = Input.GetAxis("Horizontal") * inspectSpeed;
            float z = Input.GetAxis("Vertical") * inspectSpeed;
            float zoom = Input.GetAxis("Mouse ScrollWheel") * inspectZoomSpeed;

            heartObject.transform.Rotate(x, 0, z, Space.Self);



        }









    }


    public override void Interraction()
    {
        var playerInterract = S_ManagerManager.GetManager<S_PlayerManager>().GetPlayer().GetComponent<S_PlayerInterract>();


        if (playerInterract.GetObjectInHand() != null && heartItem != null && playerInterract.GetObjectInHand().gameObject == heartItem)
        {
            heartObject.SetActive(true);
            playerInterract.DestroyObjectInHand();
            return;
        }
        SetupPuzzle();
    }


    private void SetupPuzzle()
    {
        var playerManager = S_ManagerManager.GetManager<S_PlayerManager>();
        this.GetComponent<BoxCollider>().enabled = !this.GetComponent<BoxCollider>().enabled;
        if (!isActive)
        {
            isActive = true;
            playerManager.SetPlayerState(PlayerState.Puzzle);
            S_CameraFunction.SwitchCamera(puzzleCamera, playerManager.GetPlayerCamera());
            S_CameraFunction.LockCursor();
            return;
        }

        isActive = false;
        S_CameraFunction.SwitchCamera(playerManager.GetPlayerCamera(), puzzleCamera);
        S_CameraFunction.LockCursor();
        playerManager.SetPlayerState(PlayerState.Exploration);
    }
}
