using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformTrap : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        gameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
    }
}
