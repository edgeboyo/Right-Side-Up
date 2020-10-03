using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Interactable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Animator highlightAnim;
	public string highlightAnimBoolName = "hover";

	[HideInInspector]
	public bool pointer;

	public virtual void OnPointerClick(PointerEventData eventData)
	{

	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
		if (highlightAnim)
        {
            if (!DialogueManager.Instance.IsDialogueOpen())
            {
				highlightAnim.SetBool(highlightAnimBoolName, true);
				pointer = true;
			}
            else
            {
				highlightAnim?.SetBool(highlightAnimBoolName, false);
				pointer = false;
			}
		}
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
		if (highlightAnim)
        {
			highlightAnim?.SetBool(highlightAnimBoolName, false);
			pointer = false;
		}
	}
}