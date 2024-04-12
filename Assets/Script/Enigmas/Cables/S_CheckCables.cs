using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CheckCables : Interractibles
{

    private bool isActive;
    [SerializeField]
    private Camera puzzleCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetupPuzzle();
        }


        if (!isActive)
        {
            return;
        }

    }






    public override void Interraction()
    {
      //  var playerInterract = S_ManagerManager.GetManager<S_PlayerManager>().GetPlayer().GetComponent<S_PlayerInterract>();

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
