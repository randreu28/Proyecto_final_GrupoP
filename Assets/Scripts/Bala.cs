using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float despawn = 5f;

    public Transform balaMuzzle;

    public GameObject ParticulaSangre;

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

            GameObject ParticulaClone = Instantiate(ParticulaSangre, balaMuzzle.position, Quaternion.Euler(balaMuzzle.forward), transform);
            Destroy (other.gameObject, despawn);
        }
       
        
    }

}
