using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCollectable : MonoBehaviour
{
    public float points = 25f;
    public GameObject effect;
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.GetComponent<CollectableHandler>().Collectable(points);
            Destroy(gameObject);
            Instantiate(effect, this.transform.position, this.transform.rotation*Quaternion.Euler(90, 0, 0));
        }
    }
}
