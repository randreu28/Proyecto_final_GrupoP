using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMap : MonoBehaviour
{
    public GameObject[] Prefabs;

    void Start()
    {
        Instantiate(
            Prefabs[Random.Range(0, Prefabs.Length)],
            transform.position,
            Quaternion.Euler(Vector3.up*(Random.Range(0,4)*45))
        );
    }
}
