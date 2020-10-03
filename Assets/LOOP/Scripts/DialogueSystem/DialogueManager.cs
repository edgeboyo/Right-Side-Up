using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public SentencePanel sentencePanel; // reference to the sentence panel

    public static EventHandler DialogueContinued; // after the dialogue is continued

    private Dialogue currentDialogue; // currently played dialogue
    private int currentSentenceIndex; // number of the current sentence in dialogue


    private void Awake()
    {
        Instance = this;
    }


    // -------------------------------------------------------------------- DEAFULT DIALOGUE CONTROL 

    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        currentSentenceIndex = 0;

        sentencePanel.Show(currentDialogue.GetSentence(currentSentenceIndex));
    }

    public void ContinueDialogue()
    {
        currentSentenceIndex++;

        sentencePanel.Show(currentDialogue.GetSentence(currentSentenceIndex));

        OnDialogueContinued();
    }

    public void EndDialogue()
    {
        sentencePanel.Show(null);
    }

    // ------------------------------------------------------------------- MANUAL DIALOGUE CONTROL

    // Shows a given sentence. Current dialogue stays the same.
    public void ShowSentence(Sentence sentence)
    {
        sentencePanel.Show(sentence);
    }

    // Adds repsonses to the current sentence.
    public void AddResponses(List<Response> responses)
    {
        sentencePanel.AddResponses(responses);
    }

    // Jumps forward a given number of sentences in the current dialogue.
    public void JumpForward(int length)
    {
        currentSentenceIndex += length;
    }


    // ------------------------------------------------------------------- HELPERS

    public bool IsDialogueOpen()
    {
        return currentDialogue;
    }

    public void DialogueEnded()
    {
        currentDialogue = null;
    }

    public void OnDialogueContinued()
    {
        DialogueContinued?.Invoke(this, new EventArgs());
    }
}
