using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClip", menuName = "ScriptableObject/Data/AudioClip", order = 1)]
public class AudioClipSO : ScriptableObject
{
    [SerializeField]
    private AudioClip jumpAudio;
    public AudioClip JumpAudio => jumpAudio;
    [SerializeField]
    private AudioClip deadAudio;
    public AudioClip DeadAudio => deadAudio;
    [SerializeField]
    private AudioClip fallAudio;
    public AudioClip FallAudio => fallAudio;
    [SerializeField]
    private AudioClip scoreAudio;
    public AudioClip ScoreAudio => scoreAudio;
    [SerializeField]
    private AudioClip sceneAudio;
    public AudioClip SceneAudio => sceneAudio;
}
