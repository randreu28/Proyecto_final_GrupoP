using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMap : MonoBehaviour
{
    public Material[] Materials;

    public bool rotatesX = false;
    public bool rotatesY = false;
    public bool rotatesZ = false;

    void Start()
    {
        float _rotationX = rotatesX ? 1*(Random.Range(0,4)*45) : 1;
        _rotationX = _rotationX % 90 == 0 ? _rotationX + 45 : _rotationX;
        float _rotationY = rotatesY ? 1*(Random.Range(0,4)*45) : 1;
        float _rotationZ = rotatesZ ? 1*(Random.Range(0,4)*45) : 1;

        /* Instantiate(
            Prefabs[Random.Range(0, Prefabs.Length)],
            transform.position,
            Quaternion.Euler(new Vector3(_rotationX, _rotationY, _rotationZ))
        ); */

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(5, Random.Range(1,5)*10, 5);
        cube.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + gameObject.transform.localScale.y/2, gameObject.transform.position.z);
        cube.transform.rotation = Quaternion.Euler(new Vector3(1, _rotationY, 1));
        cube.GetComponent<Renderer>().material = Materials[Random.Range(0, Materials.Length)];
    }
}
