using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    public Transform currentCheckpoint;

    public void changeCheckpoint(Transform newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
    }

    public void respawnPlayer()
    {
        transform.position = currentCheckpoint.position;
        Physics.SyncTransforms();
    }
}
