using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableHandler : MonoBehaviour
{
    public AudioClip AudioClip;
    [Range(0, 1)]
    public float volume = 1f;
    public GameObject ScoreText;

    private AudioSource SFX;
    private float Score = 0;

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
        Score = Score + 10;
        ScoreText.GetComponent<Text>().text = "Score: " + Score;
    }

}
