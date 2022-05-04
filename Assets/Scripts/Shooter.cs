using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public static Shooter instance;
    public GameObject bala;
    public Transform spawnBala;

    public float shotForce = 2000;
    public float shotRate = 1f;

    private float shotRateTime = 0;

    public float recoilForce = 4f; //Fuerza de retroceso

    public GameObject pistola;

    public Vector3 uwu;

    private void Start()
    {
        uwu = pistola.transform.localPosition;
    }
    private void Update()
    {

        pistola.transform.localPosition = Vector3.Lerp(pistola.transform.localPosition, uwu, Time.deltaTime * 5f); //pistola vuelve a su posicion
    }

    // Update is called once per frame
    void OnFire1(InputValue input)
    {

        if (input.isPressed)
        {   
            if (Time.time > shotRateTime)
            {

                
                GameObject newbala;

                AddRecoil();

                newbala = Instantiate(bala, spawnBala.position, spawnBala.rotation);

                newbala.GetComponent<Rigidbody>().AddForce(spawnBala.forward*shotForce);

                shotRateTime = Time.time + shotRate;

                

                Destroy (newbala, 4);

            }
        }
        
    }

    private void AddRecoil()
    {

        
        pistola.transform.Rotate(-recoilForce, 0f, 0f);
        pistola.transform.position = pistola.transform.position - pistola.transform.right * (recoilForce/50f);
    }

    

    
} 
