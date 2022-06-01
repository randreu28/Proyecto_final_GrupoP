using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform checkPoint;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<RespawnSystem>().changeCheckpoint(checkPoint);
        }
    }
}
