using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Base script for every scene. Manages transitions between scenes, music fading and shows dialogue on entering the scene.
 */
public class SceneControl : MonoBehaviour
{
    [Header("References")]
    public RectTransform transitionPanel;
    public AudioSource music;

    [Header("Scene")]
    public int nextSceneId;

    public static SceneControl Instance { get; private set; }

    // transition tweening
    private const float transitionEnterX = 1000;
    private const float transitionCenterX = 0;
    private const float transitionExitX = -1000;
    private const float transitionTime = 1;         // how long it takes for the transition panel to move
    private const LeanTweenType enterEase = LeanTweenType.easeInOutExpo;
    private const LeanTweenType exitEase = LeanTweenType.easeInOutExpo;

    private const float sceneChangeDelay = 0.1f; // time before the scene is changed

    private const float enterDelay = 0.5f; // delay before the transition panel exits the screen
    private const float exitDelay = 1.5f; // delay before the transition panel enters the screen

    public bool Exiting { get; private set; } // if the scene is being quitted

    
    private float _musicTimer;  // timer for music fade
    private float _musicVolume; // base music volume



    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Enter();

        _musicVolume = music.volume;
    }

    private void Update()
    {
        if (!Exiting)
        {
            _musicTimer += Time.deltaTime;
        }
        else
        {
            _musicTimer -= Time.deltaTime;
        }

        music.volume = Mathf.Min(1, _musicTimer / transitionTime) * _musicVolume;


        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeScene(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeScene(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ChangeScene(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                ChangeScene(4);
            }
        }

    }

    public void Enter()
    {
        transitionPanel.gameObject.SetActive(true);

        LeanTween.moveX(transitionPanel, transitionEnterX, transitionTime).setEase(enterEase).setFrom(transitionCenterX).setDelay(enterDelay);
    }

    public void Exit()
    {
        Exiting = true;

        _musicTimer = transitionTime;

        LeanTween.moveX(transitionPanel, transitionCenterX, transitionTime).setEase(exitEase).setFrom(transitionExitX).setDelay(exitDelay);

        StartCoroutine("NextScene");
    }

    public void FadeToBlack()
    {
        _musicTimer = transitionTime;

        Exiting = true;

        LeanTween.moveX(transitionPanel, transitionCenterX, transitionTime + 0.5f).setEase(exitEase).setFrom(transitionExitX);
    }

    public void Unfade()
    {
        Exiting = false;

        _musicTimer = transitionTime;

        LeanTween.moveX(transitionPanel, transitionEnterX, transitionTime + 0.5f).setEase(enterEase).setFrom(transitionCenterX);
    }

    public void ChangeScene(int id)
    {
        StartCoroutine("ToScene", id);
    }

    public bool IsSceneActive()
    {
        return !Exiting;
    }

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(transitionTime + sceneChangeDelay + exitDelay);

        SceneManager.LoadScene(nextSceneId);

        yield break;
    }

    private IEnumerator ToScene(int id)
    {
        yield return new WaitForSeconds(sceneChangeDelay + exitDelay);

        SceneManager.LoadScene(id);

        yield break;
    }

    
}
