using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bala;
    public Transform spawnBala;

    public float shotForce = 2000;
    public float shotRate = 1f;

    private float shotRateTime = 0;



    // Update is called once per frame
    void OnFire1(InputValue input)
    {

        if (input.isPressed)
        {   
            if (Time.time > shotRateTime)
            {
                GameObject newbala;

                newbala = Instantiate(bala, spawnBala.position, spawnBala.rotation);

                newbala.GetComponent<Rigidbody>().AddForce(spawnBala.forward*shotForce);

                shotRateTime = Time.time + shotRate;

                Destroy (newbala, 4);
            }
        }
        
    }
} 
