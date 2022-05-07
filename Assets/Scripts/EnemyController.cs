using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController: MonoBehaviour
{
    public NavMeshAgent navMeshAgent;               
    public float startWaitTime = 4; //Tiempo de espera por accion
    public float timeToRotate = 2; //Tiempo hasta que el enemigo ve al player
    public float speedWalk = 6;                     
    public float speedRun = 9;                      

    public float viewRadius = 15;                   
    public float viewAngle = 90; //Angulo de vision
    public LayerMask playerMask;                    
    public LayerMask obstacleMask;                  
    public float meshResolution = 1.0f;             
    public int edgeIterations = 4;                  
    public float edgeDistance = 0.5f;               


    public Transform[] waypoints; //  Waypoints para patroll
    int m_CurrentWaypointIndex;  //  Waypoint activo en ese momento

    Vector3 playerLastPosition = Vector3.zero; //Ultima posicion del player antes de evadirse
    Vector3 m_PlayerPosition; //Ultima posicion del player en persecucion

    float m_WaitTime;                               
    float m_TimeToRotate;                           
    bool m_playerInRange;                           
    bool m_PlayerNear;                              
    bool m_IsPatrol;                                
    bool m_CaughtPlayer;                            

    //ShootControl
    public Transform target;
    public Transform Gun;

    public GameObject SonidoCarga;

    public GameObject SonidoRevolver;

    public float shootDistance =10f;
    public float shootInterval = 2f; //tiempo entre disparos
    float shootTime; 
    float distanceToTarget;

    public GameObject bala;
    public Transform spawnBala;
    public float shotForce = 2000;
    public float shotRate = 1f;
    private float shotRateTime = 0;

    void Start()
    {
        m_PlayerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_playerInRange = false;
        m_PlayerNear = false;
        m_WaitTime = startWaitTime;                
        m_TimeToRotate = timeToRotate;

        m_CurrentWaypointIndex = 0; //Waypoint inicial
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;             
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);    



        shootTime = shootInterval;
    }

    private void Update()
    {
            EnviromentView();  //Check si el player esta en el rango de vision del enemy        

        if (!m_IsPatrol)
        {
            Chasing();
        }
        else
        {
            Patroling();
        }
    }

    private void Chasing()
    {
        m_PlayerNear = false; 
        playerLastPosition = Vector3.zero; //  Resetea la posicion del jugador

        if (!m_CaughtPlayer)
        {

            Move(speedRun);
            navMeshAgent.SetDestination(m_PlayerPosition);  //Set de la direccion del enemy a la ubicacion del player

            ShootControl();
            
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)  // Controla si el enemy llega a la posicion del player
        {
                if (m_WaitTime <= 0 && !m_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {
                // Check si el enemy no esta cerca del player, return patroll despues del tiempo de espera
                m_IsPatrol = true;
                m_PlayerNear = false;
                Move(speedWalk);
                m_TimeToRotate = timeToRotate;
                m_WaitTime = startWaitTime;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
            else
            {
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                    Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }

    private void Patroling()
    {
        if (m_PlayerNear)
        {
            //Check si el enemy detecta cerca el player, entonces el enemy va a esa posicion
            if (m_TimeToRotate <= 0)
            {
                Move(speedWalk);
                LookingPlayer(playerLastPosition);
            }
            else
            {
                
                Stop();
                m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            m_PlayerNear = false;  //  El player no esta cerca, e enemy hace patroll
            playerLastPosition = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);   
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                //  El enemy espera un tiempo antes de cambiar de waypoint
                if (m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    m_WaitTime = startWaitTime;
                }
                else
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }

    private void OnAnimatorMove()
    {

    }

    public void NextPoint()
    {
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }

    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }

    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }

    void CaughtPlayer()
    {
        m_CaughtPlayer = true;
    }

    void LookingPlayer(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 0.3)
        {
            if (m_WaitTime <= 0)
            {
                m_PlayerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }

    void ShootControl()
    {
        shootTime -= Time.deltaTime;

        if(shootTime < 0)
        {

            if(distanceToTarget < shootDistance)
            {
                shootTime = shootInterval;

                GameObject newbala;

                Instantiate(SonidoCarga);

                newbala = Instantiate(bala, spawnBala.position, spawnBala.rotation);

                Instantiate(SonidoRevolver);

                shotRateTime = Time.time + shotRate;

                newbala.transform.LookAt(target.position);

            }
        }
    }

    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);   

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);          //  Distancia del enemy y player
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_playerInRange = true;             //  Comienza a perseguir
                    m_IsPatrol = false;                 //  Cambio de estado
                }
                else
                {
                    //Si el player esta escondido en un objecto, no se registra su posicion
                    m_playerInRange = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                // Si el player esta mas lejos que el view radius, el enemy deja de seguirlo
                m_playerInRange = false;                
            }
            if (m_playerInRange)
            {
                //Si el enemy no ve al player, regresa a su posicion
                m_PlayerPosition = player.transform.position;     
            }
        }
    }
}

