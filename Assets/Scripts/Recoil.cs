using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Recoil : MonoBehaviour
{
    // Start is called before the first frame update
    public static Shooter instance;
    public GameObject bala;
    

    public float shotForce = 2000;
    public float shotRate = 1f;

    private float shotRateTime = 0;

    public float recoilForce = 4f; //Fuerza de retroceso



    // Update is called once per frame
    void OnFire1(InputValue input)
    {

        if (input.isPressed)
        {   
            if (Time.time > shotRateTime)
            {

                AddRecoil();
               
                shotRateTime = Time.time + shotRate;

            }
        }
        
    }

    private void AddRecoil()
    {

        Debug.Log("hola");
        transform.Rotate(-recoilForce, 0f, 0f);
        transform.position = transform.position - transform.forward * (recoilForce/50f);
    }

}