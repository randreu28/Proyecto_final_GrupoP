using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float delay = 3f;

    void Awake(){
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy ()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
