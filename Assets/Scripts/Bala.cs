using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float despawn = 0.5f;
    //public GameObject Enemigo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.layer == LayerMask. NameToLayer("Enemigo"))
        {
            Destroy (other.gameObject, despawn);
        }
       
        
    }
}
