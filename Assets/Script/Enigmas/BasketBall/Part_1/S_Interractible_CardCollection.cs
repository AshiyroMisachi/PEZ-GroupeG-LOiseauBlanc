using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interractible_CardCollection : Interractibles
{
    private bool isActive, isFinished, firstInterract;
    [SerializeField]
    private SO_Dialogue firstInterractDialogue, finishDialogue;

    [SerializeField]
    private Camera puzzleCamera;

    private S_BasketBall_Card currentCard;
    [SerializeField]
    private float currentCardHigh;

    [SerializeField]
    private S_BasketBall_Card[] cards;
    [SerializeField]
    private int[] cardPositionOrders;

    [SerializeField]
    private GameObject pionBox;

    public override void Interraction()
    {
        if (!firstInterract)
        {
            firstInterract = true;
            StartCoroutine(S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(firstInterractDialogue));
        }

        SetupPuzzle();
    }

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

        if (VerifyCardPositionOrder() && !isFinished)
        {
            isFinished = true;
            StartCoroutine(S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(finishDialogue));
            pionBox.SetActive(true);
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

    public void SelectCard(S_BasketBall_Card card)
    {
        if (isFinished)
        {
            return;
        }

        if (currentCard == null)
        {
            currentCard = card;
            currentCard.transform.localPosition = new Vector3(currentCard.transform.localPosition.x, currentCardHigh, currentCard.transform.localPosition.z);
            return;
        }

        //Reset Card high
        currentCard.transform.localPosition = new Vector3(currentCard.transform.localPosition.x, currentCardHigh, currentCard.transform.localPosition.z);
        Vector3 currentCardPosition = currentCard.transform.localPosition;
        int currentCardPositionOrder = currentCard.GetPositionOrder();

        currentCard.SetPositionOrder(card.GetPositionOrder());
        currentCard.transform.localPosition = card.transform.localPosition;
        card.transform.localPosition = currentCardPosition;
        card.SetPositionOrder(currentCardPositionOrder);
        currentCard = null;
    }

    public bool VerifyCardPositionOrder()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetPositionOrder() != cardPositionOrders[i])
            {
                return false;
            }
        }
        return true;
    }
}