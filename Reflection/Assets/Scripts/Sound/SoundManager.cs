﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource audioPlayer;

    public List<SoundObject> soundsList;

    public static SoundManager instance;

    Dictionary<string, AudioClip> soundDicitionary;
    // Use this for initialization
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start () {
        soundDicitionary = new Dictionary<string, AudioClip>();
        foreach (SoundObject soundObj in soundsList)
        {
            //Don't play sound if it doesn't exist
            soundDicitionary[soundObj.name] = soundObj.audioClip;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlaySound(string name)
    {
        AudioClip audioClip = soundDicitionary[name];
        audioPlayer.PlayOneShot(audioClip);
    }
}
