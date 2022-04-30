using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;

public class ChangeScene : MonoBehaviour
{
    public string scene;
    public string player;
    public float delay;
    public Volume volume;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player)
            StartCoroutine(changeScene());
    }

    IEnumerator changeScene() //1. Creixer fins al tamany doble en 1s
    {
        StartCoroutine(FBX());
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

    IEnumerator FBX()
    {
        LensDistortion distortion;
        if (volume.profile.TryGet<LensDistortion>(out distortion))
        {
            float timeElapsed = 0;
            while (timeElapsed < delay)
            {
                distortion.intensity.value = Mathf.Lerp(0, 1, timeElapsed / delay); 
                distortion.xMultiplier.value = (Mathf.Sin(timeElapsed * 5) + 1) / 2;
                distortion.yMultiplier.value = (Mathf.Cos(timeElapsed * 5) + 1) / 2;
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
