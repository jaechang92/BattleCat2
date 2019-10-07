using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControll : MonoBehaviour {
    static public SoundControll instance;

    private void Awake()
    {
        instance = this;
    }

    public List<AudioClip> BackgroundSoundClipList;

    public List<AudioClip> ClickSoundClipList;

    public List<AudioClip> HitSoundClipList;

    public AudioSource MyAudio;


    private void Start()
    {
        MyAudio = GetComponent<AudioSource>();
    }

    public void NullSound()
    {
        MyAudio.clip = null;
    }

    public void BackgoundSoundChange(int index)
    {
        NullSound();
        //yield return new WaitForSecondsRealtime(0.5f);
        MyAudio.clip = BackgroundSoundClipList[index];
        MyAudio.Play();
    }


    public void ClickSoundPlay(int index)
    {
        MyAudio.PlayOneShot(ClickSoundClipList[index]);
    }

    public void ClickSoundPlay(int index, float soundVolume)
    {
        MyAudio.PlayOneShot(ClickSoundClipList[index], soundVolume);
    }

    public void HitSoundPlay(int index)
    {
        MyAudio.PlayOneShot(HitSoundClipList[index]);
    }

    public void HitSoundPlay(int index, float soundVolume)
    {
        MyAudio.PlayOneShot(HitSoundClipList[index], soundVolume);
    }
}
