using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S_DialogueManager : Manager
{
    [SerializeField]
    private GameObject dialogueBox;
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    [SerializeField]
    private float timePerWord = 0.5f;

    public IEnumerator SendDialogue(SO_Dialogue dialogues)
    {
        dialogueBox.SetActive(true);
        for (int i = 0; i < dialogues.dialogue.Length; i++)
        {
            dialogueText.text = dialogues.dialogue[i];
            yield return new WaitForSeconds(dialogues.dialogue[i].Length * timePerWord);
        }
        dialogueBox.SetActive(false);
        yield return null;
    }
}