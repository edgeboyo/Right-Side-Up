using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweeningPanel : MonoBehaviour
{
    public RectTransform rect;
    public CanvasGroup canvasGroup;

    public LeanTweenType enterEase;
    [Range(0,3)]
    public float enterDuration;
    public Vector2 enterPos;
    public float enterAlpha;

    public LeanTweenType exitEase;
    [Range(0,3)]
    public float exitDuration;
    public Vector2 exitPos;
    public float exitAlpha;

    [HideInInspector]
    public bool entered;


    private float _currentDelay;


    private void Start()
    {
        Hide();
    }

    public void Hide()
    {
        entered = false;
        Cancel();
        LeanTween.moveLocal(gameObject, exitPos, 0);
        LeanTween.alphaCanvas(canvasGroup, exitAlpha, 0);
    }

    public void Enter()
    {
        entered = true;
        Cancel();
        LeanTween.moveLocal(gameObject, enterPos, enterDuration).setEase(enterEase).setFrom(exitPos).setDelay(_currentDelay);
        LeanTween.alphaCanvas(canvasGroup, enterAlpha, enterDuration).setEase(enterEase).setDelay(_currentDelay);
        _currentDelay = 0;
    }

    public void Exit()
    {
        entered = false;
        Cancel();
        LeanTween.moveLocal(gameObject, exitPos, exitDuration).setEase(exitEase).setDelay(_currentDelay);
        LeanTween.alphaCanvas(canvasGroup, exitAlpha, exitDuration).setEase(exitEase).setDelay(_currentDelay);
        _currentDelay = 0;
    }

    public void SetDelay(float delay)
    {
        _currentDelay = delay;
    }

    private void Cancel()
    {
        LeanTween.cancel(gameObject);
    }
}
