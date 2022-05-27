using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Negative : MonoBehaviour
{
    public float points = 5f;
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.GetComponent<CollectableHandler>().Negative(points);
        }
    }
}
