using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S_Interractible_BasketBallGame : Interractibles
{
    private bool isActive, isFinished, firstInterract, ballThrowed;

    [SerializeField]
    private Camera puzzleCamera;

    [SerializeField]
    private GameObject ballBox, ballBoxOpen;

    [SerializeField]
    private float actualForce, forceAugmentation, launchForce;

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

    [SerializeField]
    private int score, finishScore;

    [SerializeField]
    private SO_Dialogue firstInterractDialogue, finishDialogue;

    [SerializeField]
    private TextMeshProUGUI scoreText;

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

        if (!isFinished && score >= finishScore)
        {
            isFinished = true;
            StartCoroutine(S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(finishDialogue));

            //Unlock Thing for train
        }

        LaunchBall();
        ReplaceBall();
    }

    public override void Interraction()
    {
        var playerInterract = S_ManagerManager.GetManager<S_PlayerManager>().GetPlayer().GetComponent<S_PlayerInterract>();

        if (!firstInterract)
        {
            firstInterract = true;
            StartCoroutine(S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(firstInterractDialogue));
        }

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
        if (ballThrowed)
        {
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            actualForce += forceAugmentation * Time.deltaTime;
            actualForce = Mathf.Clamp01(actualForce);
            launchingPad.transform.localEulerAngles = Vector3.Lerp(lauchingPadBaseRotation, launchingPadChargedRotation, actualForce);
        }

        if (Input.GetButtonUp("Fire1") && actualForce > 0)
        {
            launchingPad.transform.localEulerAngles = lauchingPadBaseRotation;

            if (currentBall != null)
            {
                currentBall.GetComponent<S_BasketBallGame_Ball>().StartLaunch();
                currentBall.transform.parent = null;
                currentBall.GetComponent<Rigidbody>().isKinematic = false;
                Vector3 direction = Vector3.Normalize(launchDirection.transform.position - currentBall.transform.position);
                currentBall.GetComponent<Rigidbody>().AddForce(direction * actualForce * launchForce);

                ballThrowed = true;
            }

            actualForce = 0;
        }
    }

    private void ReplaceBall()
    {
        if (ballBoxOpen.activeSelf && currentBall == null)
        {
            currentBall = Instantiate(prefabBall, launchingPad.transform);
            currentBall.transform.localPosition = ballSpawnPosition;
            currentBall.GetComponent<Rigidbody>().isKinematic = true;
            currentBall.GetComponent<S_BasketBallGame_Ball>().SetBasketBallGame(this);
        }
    }

    public void DestroyCurrentBall()
    {
        Destroy(currentBall.gameObject);
        ballThrowed = false;
        currentBall = null;
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
}