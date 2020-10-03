﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPC : Interactable
{
	public GameObject achtungSign;

	public Dialogue dialogue;

	//public List<Clue> hadAchtungClues;
	//public List<Clue> notHadAchtungClues;

	//public bool canOnlyTalkOnce;

	

	private bool hasTalked;


    private void Start()
    {
        if (achtungSign != null)
        {
			//Debug.Log(ClueManager.Instance);
			//ClueManager.Instance.CluesChanged += OnCluesChanged;
		}
			
    }



    public void StartConversation()
	{
		if (hasTalked || DialogueManager.Instance.IsDialogueOpen())
		{
			return;
		}

		if (dialogue)
		{
			DialogueManager.Instance.StartDialogue(dialogue);

			/*
			if (canOnlyTalkOnce)
			{
				hasTalked = true;
			}
			*/
		}
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
        if (pointer)
        {
			StartConversation();
			//PlayerController.Instance.npcMovement.TalkTo(transform);
		}
	}

	/*
	public void OnCluesChanged(object o, EventArgs e)
    {
		bool ok = false;

		for(int i=0; i<hadAchtungClues.Count; i++)
        {
            if (ClueManager.Instance.CheckClue(hadAchtungClues[i]))
            {
				ok = true;
            }
        }

		for (int i = 0; i < notHadAchtungClues.Count; i++)
		{
			if (!ClueManager.Instance.CheckClue(notHadAchtungClues[i]))
			{
				ok = true;
			}
		}

		achtungSign.SetActive(ok);
    }
	*/
}