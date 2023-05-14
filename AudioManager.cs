using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public AudioSource[] soundEffects;

    void Start() {
        instance = this;
    }
    
    public void PlaySoundEffect(int sound){
        soundEffects[sound].Play();
    }

    public void StopSoundEffect(int sound){
        soundEffects[sound].Pause();
    }
}
