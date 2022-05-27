using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float points = 10f;
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.GetComponent<CollectableHandler>().Collectable(points);
            Destroy(gameObject);
        }
    }
}
