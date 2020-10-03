using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ResponseType
{
    Continue,           // continue to the next sentence in the dialogue
    End,                // end the dialogue
    StartNew            // begin new dialogue
}

[Serializable]
public class Sentence
{
    public DialogueActor actor;         // the character that is speaking
    [TextArea]
    public string text;                 // main body of text
    public List<Response> responses;    // available response choices. Empty list means "continue to the next sentence"
    public List<UnityEvent> events;     // events fired when this sentence is shown
    //public Clue foundClue;              // the clue to be found after this sentence
    //public Clue lostClue;               // the clue to be lost after this sentence
}

[Serializable]
public class Response
{
    public string text;                 // text shown on the choice button
    public ResponseType type;           // type of the response
    public Dialogue newDialogue;        // reference to the dialogue branch entered after clicking (if type == StartNew)
    public List<UnityEvent> events;     // events to fire when response clicked (if type == Event)
    //public Clue requiredClue;           // clue required for this response
    public string website;              // website to open
}

public class Dialogue : MonoBehaviour
{
    public string title;                // dielogue's title - just for identification
    public List<Sentence> sentences;    // list of sentences

    public Sentence GetSentence(int index)  // get the sentence at a given index (or null)
    {
        if (index >= sentences.Count)
            return null;
        else
            return sentences[index];
    }
}
