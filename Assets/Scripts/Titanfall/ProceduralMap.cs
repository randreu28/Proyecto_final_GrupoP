using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMap : MonoBehaviour
{
    public Material[] materials;
    public GameObject[] collectables;

    public float max_X = 20f;
    public float max_Y = 40f;
    public float max_Z = 20f;

    [Range (0, 1)]
    public float randomness = 0.5f;

    void Start()
    {
        if(Random.value > randomness)
        {
            //Bulding
            GameObject building = GameObject.CreatePrimitive(PrimitiveType.Cube);
            building.transform.localScale = new Vector3(Random.Range(1 ,max_X/10f)*10, Random.Range(1 ,max_Y/10f)*10, Random.Range(1 ,max_Z/10f)*10);
            building.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + building.transform.localScale.y/2, gameObject.transform.position.z);
            building.transform.rotation = Quaternion.Euler(new Vector3(1, Random.Range(0,4)*45, 1));
            building.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];

            //Collectable
            GameObject myCollectable = Instantiate(collectables[Random.Range(0, collectables.Length)], new Vector3(building.transform.position.x, building.transform.position.y * 2 + 5, building.transform.position.z), Quaternion.identity);

            //Not really necessary. Just for order
            building.transform.parent = GameObject.Find("Enviroment").transform;
            building.name = "Building";
            myCollectable.transform.parent = building.transform;
        }
    }
}
