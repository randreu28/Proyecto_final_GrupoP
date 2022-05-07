using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bala2 : MonoBehaviour
{
    public float speed = 8f;

    public float lifeDuration = 2f;

    float lifeTimer;

    public float despawn = 5f;

    public GameObject SonidoHit;

    public GameObject SonidoRevolver;

    void Start()
    {
        lifeTimer = lifeDuration;

        
    }

    void Update()
    {
        BorrarBala(); //elimina el object bala2(clone)
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Instantiate (SonidoHit);
            Instantiate(SonidoRevolver);
            Debug.Log("Ouch");
        }
    }

    void BorrarBala()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy (gameObject, despawn);
        }
    }
}
