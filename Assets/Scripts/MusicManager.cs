using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager instance;
    
    public AudioClip audioClip1;
    public AudioSource AudioSource;

    private void Awake() {
        instance = this;
    }

    // 음악 시작하기
    private void Start() {
        AudioSource.clip = audioClip1;
        AudioSource.Play();
    }

    // 음악 빠르게
    public void PitchUp() {
        this.gameObject.GetComponent<AudioSource>().pitch = 1.15f;
    }

    // 음악 느리게 
    public void PitchDown() {
        this.gameObject.GetComponent<AudioSource>().pitch = 1f;
    }
}
