using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class S_DialogueManager : Manager
{
    [Header("ReferenceUI")]
    [SerializeField]
    private GameObject dialogueBox;
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    [Header("Setup Var")]
    [SerializeField]
    private float timePerWord = 0.5f;

    [SerializeField]
    private SO_Dialogue[] dialogueList;
    [SerializeField]
    private float[] timeDialogueList;
    private int currentDialogue = 0;

    private List<SO_Dialogue> dialogueShowList;

    private void Start()
    {
        dialogueShowList = new List<SO_Dialogue>();
        StartCoroutine(DialogueActivation());
    }

    private void Update()
    {
        if (timeDialogueList.Length == 0)
        {
            return;
        }

        if (S_ManagerManager.GetManager<S_TimeManager>().GetTime() >= timeDialogueList[currentDialogue])
        {
            if (dialogueList[currentDialogue] != null)
            {
                SendDialogue(dialogueList[currentDialogue]);
                dialogueList[currentDialogue] = null;
                currentDialogue++;
                currentDialogue = (int)Mathf.Clamp(currentDialogue, 0, timeDialogueList.Length - 1);
            }
        }
    }

    public void SendDialogue(SO_Dialogue dialogues)
    {
        dialogueShowList.Add(dialogues);
    }

    public IEnumerator DialogueActivation()
    {
        while (true)
        {
            if (dialogueShowList.Count > 0)
            {
                if (dialogueShowList[0] != null)
                {
                    var dialogues = dialogueShowList[0];
                    dialogueBox.SetActive(true);
                    for (int i = 0; i < dialogues.dialogue.Length; i++)
                    {
                        dialogueText.text = dialogues.dialogue[i];
                        yield return new WaitForSeconds(dialogues.dialogue[i].Length * timePerWord);
                    }
                    dialogueBox.SetActive(false);
                    dialogueShowList.RemoveAt(0);
                }
            }
            yield return new WaitForSeconds(2f);
        }
    }
}