using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public ParticleSystem fireworks;
    public ParticleSystem subEmitter;

    public AudioClip AudioClip;
    [Range(0, 1)]
    public float volume = 1f;

    public Gradient[] myGradients;

    private bool isMoving = false;
    private Vector3 starterPosition;
    private Vector3 newPosition;
    private int state = 0;
    private AudioSource SFX;

    void Awake()
    {
        starterPosition = this.transform.position;
        newPosition = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);

        SFX = this.gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        SFX.clip = AudioClip;
        SFX.volume = volume;
    }
    void OnCollisionEnter()
    {
        if(isMoving == false)
        {
            StartCoroutine(PushButton());
        }
    }

    public IEnumerator PushButton()
    {
        SFX.Play();
        ChangeColor();
        isMoving = true;
        yield return StartCoroutine(LerpPosition(this.gameObject, starterPosition, newPosition, 1));
        yield return StartCoroutine(LerpPosition(this.gameObject, newPosition, starterPosition, 1));
        isMoving = false;
    }

    public void ChangeColor()
    {
        var mainFireworks = fireworks.main;        
        var trailFireworks = fireworks.trails;

        var mainSubemitters = subEmitter.main;        
        var trailSubemitters = subEmitter.trails;

        if(state != myGradients.Length)
        {
            mainFireworks.startColor = myGradients[state].Evaluate(state);
            trailFireworks.colorOverTrail = myGradients[state];

            mainSubemitters.startColor = myGradients[state].Evaluate(state);
            trailSubemitters.colorOverTrail = myGradients[state];
            state++;
        }else{
            state = 0;
            mainFireworks.startColor = myGradients[state].Evaluate(state);
            trailFireworks.colorOverTrail = myGradients[state];

            mainSubemitters.startColor = myGradients[state].Evaluate(state);
            trailSubemitters.colorOverTrail = myGradients[state];
        }
    }

    public IEnumerator LerpPosition(GameObject myObject, Vector3 startPosition, Vector3 targetPosition, float duration)
    {
        float time = 0;
        myObject.transform.position = startPosition;
        while (time < duration)
        {
            float t = time / duration;
            t = t * t * (3f - 2f * t);
            myObject.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            time += Time.deltaTime;
            yield return null;
        }
        myObject.transform.position = targetPosition;
    }
}
