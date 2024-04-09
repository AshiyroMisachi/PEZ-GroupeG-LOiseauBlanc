using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interractible_Dinette : Interractibles
{
    private bool isActive, isFisished;
    [SerializeField]
    private Camera puzzleCamera;

    [SerializeField]
    private S_Dinette_Button[] buttons;
    [SerializeField]
    private int[] correctButtonsNumbers;

    [SerializeField]
    private Animator doorAnimator;

    private void Update()
    {
        if (!isActive) return;   

        if (Input.GetKeyDown(KeyCode.P))
        {
            SetupPuzzle();
        }

        if (VerifyCorrectButton())
        {
            isFisished = true;
            SetupPuzzle();
            doorAnimator.SetTrigger("Open");
        }
    }

    public override void Interraction()
    {
        if (isFisished)
        {
            return;
        }
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
            S_CameraFunction.LockCursor();
            return;
        }

        isActive = false;
        S_CameraFunction.SwitchCamera(playerManager.GetPlayerCamera(), puzzleCamera);
        S_CameraFunction.LockCursor();
        playerManager.SetPlayerState(PlayerState.Exploration);
    }

    private bool VerifyCorrectButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetActualNumbers() != correctButtonsNumbers[i])
            {
                return false;
            }
        }
        return true;
    }
}
