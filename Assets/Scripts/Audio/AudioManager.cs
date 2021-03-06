﻿using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    public Sounding[] sounds;

    //public AudioClip clip;

    void Awake(){
        if (instance != null && instance != this){
            Destroy(gameObject);
            return;
        }else{
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sounding s in sounds){
            s.source  = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            //s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string sound)
    {
        Sounding s = Array.Find(sounds, audio => audio.name == sound);
        if (s == null){
            Debug.LogWarning("Sound: " + sound + " not found!");
            return;
        }else{
            s.source.volume = s.volume;// * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
            s.source.pitch = s.pitch;// * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

            s.source.Play();
        }
    }
}
