using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class SentencePanel : TweeningPanel
{
    public TextMeshProUGUI title; // text showing character's name
    public TextMeshProUGUI text; // main body of text
    public Image image; // character's image
    public List<ResponsePanel> responsePanels; // list of attached response panels

    private Sentence _sentence; // currently shown sentence

    private List<Response> _addedResponses = new List<Response>(); // list of manually added responses

    private const float responseDelay = 0.1f; // delay between the response buttons being shown
    private const float textShowingSpeed = 35; // how many characters are shown per second

    private float _textTimer; // timer

    private bool _noResponses; // if there are no responses available for the senetence
    private bool _fullTextShown; // if all the text has been shown

    private void Update()
    {
        // if a sentence is not set, return 
        if (_sentence == null)
            return;

        // if the text is not fully shown yet
        if (!_fullTextShown)
        {
            // show more text
            _textTimer += Time.deltaTime * textShowingSpeed;
            _textTimer = Mathf.Min(_textTimer, _sentence.text.Length);
            string currentText = _sentence.text.Substring(0, Mathf.RoundToInt(_textTimer));
            text.text = currentText;

            // show full text when timer is full
            if(_textTimer == _sentence.text.Length)
            {
                ShowFullText();
            }

            // show full text when mouse clicked
            else if (Input.GetMouseButtonDown(0))
            {
                ShowFullText();
            }
        }

        // if the text is fully shown and there are no responses for this sentence
        else if (_noResponses)
        {
            // continue dialogue when mouse clicked
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("continue");
                DialogueManager.Instance.ContinueDialogue();
            }
        }
        
    }

    // begin showing a new sentence
    public void Show(Sentence sentence)
    {
        // fire the previous sentence's events and fulfill conditions
        if (_sentence != null)
        {
            _sentence.events.ForEach(ev => ev.Invoke());
            //ClueManager.Instance.AddClue(_sentence.foundClue);
            //ClueManager.Instance.RemoveClue(_sentence.lostClue);
        }
            

        // set the current sentence (or null)
        _sentence = sentence;

        // if sentence is null
        if (sentence == null)
        {
            // end dialogue
            DialogueManager.Instance.DialogueEnded();

            // panel exit
            Exit();
            HideResponses();

            return;
        }

        // if the panel is currently hidden
        if (!entered)
        {
            // hide immediately and enter
            Hide();
            Enter();
        }

        // show stuff on the panel
        title.text = sentence.actor.title;
        image.sprite = sentence.actor.sprite;
        title.font = sentence.actor.font;
        text.font = sentence.actor.font;

        // begin showing text
        _fullTextShown = false;
        _textTimer = 0;

        // hide responses
        HideResponses();

        // play random speech
        if (sentence.actor.talk)
        {
            //AudioManager.Instance.PlayRandomSpeechSound(sentence.actor);
        }
    }



    // Add custom responses to the sentence. Used by minigames.
    public void AddResponses(List<Response> responses)
    {
        _addedResponses = responses;
    }




    // show the full text and responses
    private void ShowFullText()
    {
        _fullTextShown = true;
        ShowResponses();
        text.text = _sentence.text;
    }


    // shows responses available for the current sentence
    private void ShowResponses()
    {
        List<Response> responses = new List<Response>();

        responses.AddRange(_sentence.responses);
        responses.AddRange(_addedResponses);

        if (responses.Count > 0)
        {
            // if there are responses available - show them

            _noResponses = false;

            int j = 0;

            for (int i = 0; i < responsePanels.Count; i++)
            {
                if (responses.Count > i)
                {
                    Response response = responses[i];

                    responsePanels[j].SetDelay(responseDelay * (j + 1));
                    responsePanels[j].SetResponse(response);

                    j++;

                    // if there is no condition or condition is fulfilled
                    /*
                    if (response.requiredClue == null || ClueManager.Instance.CheckClue(response.requiredClue))
                    {
                        
                    }
                    */
                }
            }
        }
        else
        {
            // if no responses - hide all and wait for click

            _noResponses = true;

            HideResponses();
        }

        _addedResponses = new List<Response>();
    }

    // hide responses naturally - with delays
    private void HideResponses()
    {
        for (int i = 0; i < responsePanels.Count; i++)
        {
            responsePanels[i].SetDelay(responseDelay * (i + 1));
            responsePanels[i].HideResponse();
        }
    }
}
