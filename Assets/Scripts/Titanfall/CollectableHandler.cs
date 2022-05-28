using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableHandler : MonoBehaviour
{
    public AudioClip collectableSound;
    [Range(0, 1)]
    public float collectableVolume = 1f;
    
    [Space(15)]

    public AudioClip negativeSound;
    [Range(0, 1)]
    public float negativeVolume = 1f;

    [Space(15)]

    public GameObject scoreText;
    public float score = 0;

    private AudioSource collectableSFX;
    private AudioSource negativeSFX;

    void Awake(){
        //Collectable
        collectableSFX = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        collectableSFX.clip = collectableSound;
        collectableSFX.volume = collectableVolume;
        collectableSFX.pitch = collectableSFX.pitch - 0.1f;

        //Negative
        negativeSFX = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        negativeSFX.clip = negativeSound;
        negativeSFX.volume = negativeVolume;
    }

    public void Collectable(float value)
    {
        collectableSFX.pitch = collectableSFX.pitch + 0.1f;
        collectableSFX.Play();
        score = score + value;
        BroadcastMessage("OnScoreChange", score);
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    public void Negative(float value)
    {
        negativeSFX.Play();
        score = score - value;
        BroadcastMessage("OnScoreChange", score);
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }
}
