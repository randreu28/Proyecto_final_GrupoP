using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMap : MonoBehaviour
{
    public GameObject[] Prefabs;

    public bool rotatesX = false;
    public bool rotatesY = false;
    public bool rotatesZ = false;

    void Start()
    {
        float _rotationX = rotatesX ? 1*(Random.Range(0,4)*45) : 1;
        _rotationX = _rotationX % 90 == 0 ? _rotationX + 45 : _rotationX;
        float _rotationY = rotatesY ? 1*(Random.Range(0,4)*45) : 1;
        float _rotationZ = rotatesZ ? 1*(Random.Range(0,4)*45) : 1;

        Instantiate(
            Prefabs[Random.Range(0, Prefabs.Length)],
            transform.position,
            Quaternion.Euler(new Vector3(_rotationX, _rotationY, _rotationZ))
        );
    }
}
