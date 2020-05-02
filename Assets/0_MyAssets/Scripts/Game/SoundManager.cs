using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager i;
    AudioSource[] audioSources;

    void Awake()
    {
        if (i == null) i = this;
        audioSources = GetComponents<AudioSource>();
        audioSources[1].clip = SoundResourceSO.i.bgm.audioClip;
        audioSources[1].Play();
    }

    public void OnStart()
    {
    }

    public void PlayOneShot(int resourceIndex)
    {
        if (SaveData.i.isOffSE) { return; }
        if (SoundResourceSO.i.resources.Length - 1 < resourceIndex) { return; }
        AudioClip clip = SoundResourceSO.i.resources[resourceIndex].audioClip;
        if (clip == null) { return; }
        audioSources[0].PlayOneShot(clip);
    }

}
