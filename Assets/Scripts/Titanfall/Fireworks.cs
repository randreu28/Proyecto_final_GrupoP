using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{
    public ParticleSystem myFireworks;
    public float scoreTrigger = 100f;

    public AudioClip SoundEffect;
    [Range(0, 1)]
    public float SoundVolume = 1f;

    private AudioSource SFX;

    void Awake()
    {
        SFX = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        SFX.clip = SoundEffect;
        SFX.volume = SoundVolume;
    }

    void OnScoreChange(float score)
    {
        if(score >= scoreTrigger)
        {
            StartCoroutine(handleFireworks());
        }
    }
    private IEnumerator handleFireworks()
    {
        myFireworks.Play(true);
        yield return new WaitForSeconds(2.5f);
        SFX.Play();
    }
}
