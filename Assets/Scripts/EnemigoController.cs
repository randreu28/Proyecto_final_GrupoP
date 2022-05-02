using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Transform Gun;

    public float shootDistance =10f;
    public float shootInterval = 2f; //tiempo entre disparos
    float shootTime; 
    float distanceToTarget;

    NavMeshAgent agent;

    public float distanceToChase = 3f;
    public float chaseInterval = 2f;
    float chaseTime;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        shootTime = shootInterval;
        chaseTime = chaseInterval;
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 posNoRot = new Vector3(target.position.x,transform.position.y, target.position.z); //asi no se inclina
        transform.LookAt(posNoRot); //seguimiento de player

        distanceToTarget =  Vector3.Distance(transform.position, target.position);

        Chase();

        //ShootControl();
    }

    void Chase()
    {
        chaseTime -= Time.deltaTime;
        if(chaseTime < 0)
        {
            if(distanceToTarget > distanceToChase)
            {
                agent.SetDestination(target.position);
                agent.stoppingDistance = distanceToChase;
                chaseTime = chaseInterval;
            }
        }
    }

   

    /* void ShootControl()
    {
        shootTime -= Time.deltaTime;
        if(shootTime < 0)
        {
            if(distanceToTarget < shootDistance)
            {
                shootTime = shootInterval;
                GameObject bala = Shooter.newbala(false);
                bala.transform.position = gun.position;
                bala.transform.LookAt(target.position);

            }
        }
    } */
}
