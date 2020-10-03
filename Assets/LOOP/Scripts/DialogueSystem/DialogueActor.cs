using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueActor : MonoBehaviour
{
    public string title;
    public Sprite sprite;
    public TMP_FontAsset font;
    [Header("Voice")]
    public bool talk;   // if the character makes talking sounds
    [Range(0.5f,1.5f)]
    public float voicePitch = 1;
    public List<AudioClip> voiceClips;
}
