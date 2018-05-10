using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundObject{

    public string name;
    public AudioClip audioClip;
    [Range(1,100)]
    public float volume;
}
