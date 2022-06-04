using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Parenter : MonoBehaviour
{

    private void OnTriggerEnter(Collider _is)
    {
        if (_is.gameObject.tag == "Player")
        {
            _is.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider _is)
    {
        if (_is.gameObject.tag == "Player")
        {
            _is.gameObject.transform.parent = null;
        }
    }

}