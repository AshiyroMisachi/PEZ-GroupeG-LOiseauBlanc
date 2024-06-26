using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SimonManager : MonoBehaviour
{
    [SerializeField]
    private bool activated, startSequenceDone, inSequence, sequenceDone, isFinished;

    [SerializeField]
    private S_Interractible_SimonBuzzer[] buzzers;

    [SerializeField]
    private int[] lenghtSequence;

    [SerializeField]
    private int currentSequence = -1;

    [SerializeField]
    private List<int> startCurrentList, currentSequenceList, playerSequence;

    [SerializeField] private SO_Dialogue endDialogue;

    private void Start()
    {
        StartSetup();
    }
    void Update()
    {


        if (!activated || isFinished)
        {
            return;
        }

        if (!inSequence && currentSequenceList.Count == playerSequence.Count && sequenceDone)
        {
            if (VerifyCurrentSequence())
            {
                StartCoroutine(CorrectLight());
                return;
            }

            StartCoroutine(ErrorLights());
            return;
        }

        if (currentSequence == lenghtSequence.Length)
        {
            isFinished = true;
            StartCoroutine(EndLight());
            S_ManagerManager.GetManager<S_Train>().isEnigmaCompleted(3);
            S_ManagerManager.GetManager<S_DialogueManager>().SendDialogue(endDialogue);
        }
    }

    public void ActiveSimon()
    {
        activated = true;
        for (int j = 0; j < buzzers.Length; j++)
        {
            StartCoroutine(buzzers[j].ActiveLight());
        }
    }

    private void StartSetup()
    {
        currentSequence = -1;
        startSequenceDone = false;
        sequenceDone = true;
        currentSequenceList = new List<int>(startCurrentList);
    }

    public bool GetActivated()
    {
        return activated;
    }

    public bool GetInSequence()
    {
        return inSequence;
    }

    public void AddPlayerSequence(int buzzerIndex)
    {
        playerSequence.Add(buzzerIndex);
    }

    private IEnumerator RandomSequence()
    {
        currentSequenceList.Clear();
        inSequence = true;
        for (int i = 0; i < lenghtSequence[currentSequence]; i++)
        {
            int randomBuzzer = Random.Range(0, buzzers.Length);
            StartCoroutine(buzzers[randomBuzzer].ActiveLight());
            currentSequenceList.Add(randomBuzzer);
            yield return new WaitForSeconds(1f);
        }
        inSequence = false;
        sequenceDone = true;
    }

    private IEnumerator CorrectLight()
    {
        playerSequence.Clear();
        sequenceDone = false;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < buzzers.Length; j++)
            {
                StartCoroutine(buzzers[j].ActiveLight());
            }
            yield return new WaitForSeconds(1f);
        }

        if (!startSequenceDone)
        {
            startSequenceDone = true;
        }

        currentSequence++;

        if (startSequenceDone && currentSequence != lenghtSequence.Length)
        {
            StartCoroutine(RandomSequence());
        }
    }

    private IEnumerator ErrorLights()
    {
        sequenceDone = false;
        playerSequence.Clear();
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < buzzers.Length; i++)
        {
            StartCoroutine(buzzers[i].ErrorLight());

        }
        yield return new WaitForSeconds(1f);

        if (startSequenceDone)
        {
            StartCoroutine(RandomSequence());
        }
        else
        {
            sequenceDone = true;
        }
    }

    private bool VerifyCurrentSequence()
    {
        for (int i = 0; i < currentSequenceList.Count; i++)
        {
            if (currentSequenceList[i] != playerSequence[i])
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerator EndLight()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < buzzers.Length; j++)
            {
                StartCoroutine(buzzers[j].ActiveLight());
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}