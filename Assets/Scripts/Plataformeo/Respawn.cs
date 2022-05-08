using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.tag == "Player")
        {
            Debug.Log("???");
            collider.gameObject.transform.position = spawnPoint.position;
        }
    }
}
