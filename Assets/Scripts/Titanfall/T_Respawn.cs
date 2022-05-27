using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Respawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float points;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.gameObject.transform.position = spawnPoint.position;
            collider.GetComponent<CollectableHandler>().Negative(points);
            collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Physics.SyncTransforms();
        }
    }
}
