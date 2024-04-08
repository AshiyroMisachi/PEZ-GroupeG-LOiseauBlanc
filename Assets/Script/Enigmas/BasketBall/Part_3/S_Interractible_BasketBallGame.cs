using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interractible_BasketBallGame : Interractibles
{
    private bool isActive, isFinished;

    [SerializeField]
    private Camera puzzleCamera;

    [SerializeField]
    private GameObject ballBox, ballBoxOpen;

    [SerializeField]
    private float launchForce, forceAugmentation;

    [SerializeField]
    private GameObject launchDirection;

    [SerializeField]
    private GameObject launchingPad;
    [SerializeField]
    private Vector3 lauchingPadBaseRotation, launchingPadChargedRotation;

    [SerializeField]
    private GameObject prefabBall, currentBall;

    [SerializeField]
    private Vector3 ballSpawnPosition;

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        LaunchBall();
        ReplaceBall();
    }

    public override void Interraction()
    {
        var playerInterract = S_ManagerManager.GetManager<S_PlayerManager>().GetPlayer().GetComponent<S_PlayerInterract>();

        //if (!firstInterract)
        //{
        //    firstInterract = true;
        //    StartCoroutine(S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(firstInterractDialogue));
        //}

        if (playerInterract.GetObjectInHand() != null && ballBox != null && playerInterract.GetObjectInHand().gameObject == ballBox)
        {
            ballBoxOpen.SetActive(true);
            playerInterract.DestroyObjectInHand();
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
            return;
        }

        isActive = false;
        S_CameraFunction.SwitchCamera(playerManager.GetPlayerCamera(), puzzleCamera);
        playerManager.SetPlayerState(PlayerState.Exploration);
    }


    private void LaunchBall()
    {
        if (Input.GetButton("Fire1"))
        {
            launchForce += forceAugmentation * Time.deltaTime;
            launchForce = Mathf.Clamp01(launchForce);
            launchingPad.transform.localEulerAngles = Vector3.Lerp(lauchingPadBaseRotation, launchingPadChargedRotation, launchForce);
        }
        
        if (Input.GetButtonUp("Fire1") && launchForce > 0)
        {
            launchingPad.transform.localEulerAngles = lauchingPadBaseRotation;

            //YEEEEET
            currentBall.transform.parent = null;
            currentBall.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 direction = Vector3.Normalize(launchDirection.transform.position - currentBall.transform.position);
            currentBall.GetComponent<Rigidbody>().AddForce(direction * launchForce);


            launchForce = 0;
        }
    }

    private void ReplaceBall()
    {
        if (ballBoxOpen.activeSelf && currentBall == null)
        {
            currentBall = Instantiate(prefabBall, launchingPad.transform);
            currentBall.transform.localPosition = ballSpawnPosition;
            currentBall.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}