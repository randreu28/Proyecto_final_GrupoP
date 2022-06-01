using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformTrap : MonoBehaviour
    
{
    public AudioClip AudioClip;
    [Range(0, 1)]
    public float volume = 1f;

    [Space(10)]

    public float delay = 1f;
    [Range(0, 1)]
    public float probability = 0.5f;

    private bool isTrap = true;
    private AudioSource SFX;

    void Awake(){
        SFX = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        SFX.clip = AudioClip;
        SFX.volume = volume;
    }

    void OnTriggerEnter(Collider other){
        if(isTrap)
        {
            if (Random.value > probability){
                StartCoroutine(warnPlayer());
            }
            else{
                isTrap = false;
            }
        }
    }

    IEnumerator warnPlayer()
    {
        SFX.Play();
        yield return new WaitForSeconds(delay);
        gameObject.AddComponent<Rigidbody>();
        isTrap = false;
    }
}
