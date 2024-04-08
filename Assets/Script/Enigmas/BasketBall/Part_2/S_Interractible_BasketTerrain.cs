using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interractible_BasketTerrain : Interractibles
{
    [SerializeField]
    private bool isActive;
    [SerializeField]
    private Camera puzzleCamera;
    [SerializeField]
    private GameObject pionBox;
    [SerializeField]
    private GameObject pionBoxOpen;
    [SerializeField]
    private S_BasketBall_Pion[] pions;
    [SerializeField]
    private int[] pionsPosition;


    private S_BasketBall_Pion currentPion;
    [SerializeField]
    private Vector3 currentPionPosition, currentPionRotation;

    private bool isFinished = false, firstInterract = false;
    [SerializeField]
    private SO_Dialogue firstInterractDialogue, finishDialogue;

    [SerializeField]
    private GameObject ballBox;

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

        if (VerifyPionPosition())
        {
            isFinished = true;
            StartCoroutine(S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(finishDialogue));
            ballBox.SetActive(true);
            SetupPuzzle();
        }

    }

    public bool GetIsActive()
    {
        return isActive;
    }
    public override void Interraction()
    {
        var playerInterract = S_ManagerManager.GetManager<S_PlayerManager>().GetPlayer().GetComponent<S_PlayerInterract>();
        if (!firstInterract)
        {
            firstInterract = true;
            StartCoroutine(S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(firstInterractDialogue));
        }

        if (playerInterract.GetObjectInHand() != null && pionBox != null && playerInterract.GetObjectInHand().gameObject == pionBox)
        {
            pionBoxOpen.SetActive(true);
            playerInterract.DestroyObjectInHand();
            return;
        }

        if (!isFinished)
        {
            SetupPuzzle();
        }
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

    public void SetCurrentPion(S_BasketBall_Pion newPion)
    {
        if (currentPion == null)
        {
            currentPion = newPion;
            currentPion.transform.localPosition = currentPionPosition;
            currentPion.transform.localEulerAngles = currentPionRotation;
            currentPion.SetPosition(0);
            return;
        }
        //Set the current Pion with the new pick one
        currentPion.transform.localPosition = newPion.transform.localPosition;
        currentPion.transform.localEulerAngles = newPion.transform.localEulerAngles;
        currentPion.SetPosition(newPion.GetPosition());
        //the new pick one is now the current
        currentPion = newPion;

        //Set the current pion to the camera
        currentPion.transform.localPosition = currentPionPosition;
        currentPion.transform.localEulerAngles = currentPionRotation;
        currentPion.SetPosition(0);
    }

    public void PlacePion(Transform position, int number)
    {
        if (currentPion == null)
        {
            return;
        }

        currentPion.transform.position = position.position;
        currentPion.transform.eulerAngles = position.eulerAngles;
        currentPion.SetPosition(number);
        currentPion = null;
    }

    private bool VerifyPionPosition()
    {
        for (int i = 0; i < pions.Length; i++)
        {
            if (pions[i].GetPosition() != pionsPosition[i])
            {
                return false;
            }
        }
        return true;
    }
}