using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static SoundEffect instance;

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;

    public AudioSource AudioSource;

    private void Awake() {
        instance = this;
    }

    public void DieSound() {
        AudioSource.clip = audioClip1;
        AudioSource.Play();
    }

    public void ButtonSound() {
        AudioSource.clip = audioClip2;
        AudioSource.Play();
    }

    public void ClearSound() {
        AudioSource.clip = audioClip3;
        AudioSource.Play();
    }
}
