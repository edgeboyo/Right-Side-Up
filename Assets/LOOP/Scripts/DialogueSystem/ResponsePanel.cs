using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResponsePanel : TweeningPanel
{
    public TextMeshProUGUI text;

    private Response currentResponse;

    public void SetResponse(Response response)
    {
        currentResponse = response;

        text.text = response.text;

        Enter();
    }

    public void HideResponse()
    {
        currentResponse = null;

        if (entered)
        {
            Exit();
        }
    }

    public void OnClicked()
    {
        if (currentResponse == null)
            return;

        Response response = currentResponse;

        if (response.events != null && response.events.Count > 0)
        {
            response.events.ForEach(ev => ev.Invoke());
        }

        if(response.website != null && !response.website.Equals(string.Empty))
        {
            //LinkManager.OpenWebsite(response.website);
        }

        switch (response.type)
        {
            case ResponseType.Continue:
                DialogueManager.Instance.ContinueDialogue();
                break;
            case ResponseType.End:
                DialogueManager.Instance.EndDialogue();
                break;
            case ResponseType.StartNew:
                DialogueManager.Instance.StartDialogue(response.newDialogue);
                break;
        }
    }
}
