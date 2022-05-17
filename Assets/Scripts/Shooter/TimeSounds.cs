using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSounds : MonoBehaviour
{
    public float tiempo;

    void Start()
    {
        Destroy (gameObject, tiempo);
    }
}
