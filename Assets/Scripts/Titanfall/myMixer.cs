using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class myMixer : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioMixerSnapshot[] SnapShots;
    public float transitionSpeed = 1f;

    void Start()
    {
        CheckMusic(GetComponent<CollectableHandler>().score);
    }

    void OnScoreChange(float score)
    {
        CheckMusic(score);
    }

    void CheckMusic(float score)
    {
       if(score <= 0)
        {
            float[] myWeights = { 1, 0, 0, 0, 0}; 
            mixer.TransitionToSnapshots(SnapShots, myWeights, transitionSpeed);
            GameObject.Find("MusicStage").GetComponent<Text>().text = "Music Stage: 1";  
        }
        else if(score <= 10)
        {
            float[] myWeights = { 0, 1, 0, 0, 0}; 
            mixer.TransitionToSnapshots(SnapShots, myWeights, transitionSpeed);
            GameObject.Find("MusicStage").GetComponent<Text>().text = "Music Stage: 2";  
        }
        else if(score <= 20)
        {
            float[] myWeights = { 0, 0, 1, 0, 0}; 
            mixer.TransitionToSnapshots(SnapShots, myWeights, transitionSpeed);
            GameObject.Find("MusicStage").GetComponent<Text>().text = "Music Stage: 3";  
        }
        else if(score <= 30)
        {
            float[] myWeights = { 0, 0, 0, 1, 0}; 
            mixer.TransitionToSnapshots(SnapShots, myWeights, transitionSpeed);
            GameObject.Find("MusicStage").GetComponent<Text>().text = "Music Stage: 4";  
        }
        else if (score <= 40)
        {
            float[] myWeights = {0, 0, 0, 0, 1}; 
            mixer.TransitionToSnapshots(SnapShots, myWeights, transitionSpeed);
            GameObject.Find("MusicStage").GetComponent<Text>().text = "Music Stage: 5";  
        }
    }
}
