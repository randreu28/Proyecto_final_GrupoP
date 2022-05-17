using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    
    public static Shooter instance;
    public GameObject bala;
    public Transform spawnBala;

    public float shotForce = 2000;
    public float shotRate = 1f;
    private float shotRateTime = 0;

    public float recoilForce = 4f; //Fuerza de retroceso

    public GameObject pistola;
    public Vector3 zero;
    public Transform gunMuzzle;

    public GameObject ParticulaBala;

    public GameObject SonidoDisparo;

    private void Start()
    {
        zero = pistola.transform.localPosition;
    }
    private void Update()
    {
        ReturnPosition();  //pistola vuelve a su posicion
    }

    void OnFire1(InputValue input)
    {
        if (input.isPressed)
        {   
            if (Time.time > shotRateTime)
            {
                GameObject newbala;

                ParticulaBalas();

                AddRecoil();

                Instantiate(SonidoDisparo);
            
                newbala = Instantiate(bala, spawnBala.position, spawnBala.rotation);

                newbala.GetComponent<Rigidbody>().AddForce(spawnBala.forward*shotForce);

                shotRateTime = Time.time + shotRate;

                Destroy (newbala, 4);
            }
        }
    }

    //retroceso arma
    private void AddRecoil()
    {

        
        pistola.transform.Rotate(-recoilForce, 0f, 0f);
        pistola.transform.position = pistola.transform.position - pistola.transform.right * (recoilForce/50f);
    }
    //retroceso arma, volver a posicion
    void ReturnPosition()
    {
       pistola.transform.localPosition = Vector3.Lerp(pistola.transform.localPosition, zero, Time.deltaTime * 5f);
    }

    //particulas para la salida de la pistola
    private void ParticulaBalas()
    {
        GameObject ParticulaClone = Instantiate(ParticulaBala, gunMuzzle.position, Quaternion.Euler(gunMuzzle.forward), transform);
        Destroy(ParticulaClone, 2f);
    }

    

    
} 
