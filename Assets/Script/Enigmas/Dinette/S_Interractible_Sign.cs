using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interractible_Sign : Interractibles
{
    private bool isActive;

    [SerializeField]
    private Camera puzzleCamera;


    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SetupPuzzle();
        }
    }

    public override void Interraction()
    {
        SetupPuzzle();
    }

    private void SetupPuzzle()
    {
        var playerManager = S_ManagerManager.GetManager<S_PlayerManager>();
        if (!isActive)
        {
            isActive = true;
            playerManager.SetPlayerState(PlayerState.Puzzle);
            S_CameraFunction.SwitchCamera(puzzleCamera, playerManager.GetPlayerCamera());
            return;
        }

        isActive = false;
        S_CameraFunction.SwitchCamera(playerManager.GetPlayerCamera(), puzzleCamera);
        playerManager.SetPlayerState(PlayerState.Exploration);
    }
}