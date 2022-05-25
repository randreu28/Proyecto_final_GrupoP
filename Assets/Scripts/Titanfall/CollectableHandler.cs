using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHandler : MonoBehaviour
{
    public AudioClip AudioClip;
    [Range(0, 1)]
    public float volume = 1f;

    private AudioSource SFX;

    void Awake(){
        SFX = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        SFX.clip = AudioClip;
        SFX.volume = volume;
        SFX.pitch = SFX.pitch - 0.1f;
    }

    public void CollectCoin()
    {
        SFX.pitch = SFX.pitch + 0.1f;
        SFX.Play();
        //Update UI
    }

}
