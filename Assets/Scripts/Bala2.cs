using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bala2 : MonoBehaviour
{

    public float speed = 8f;
    public float lifeDuration = 2f;
    float lifeTimer;

    /* public GameObject bloodEffect;

    private Image _bloodEffect; */

    public float despawn = 5f;

    /* private float r;
    private float g;
    private float b;
    private float a; */
    

    void Start()
    {
        lifeTimer = lifeDuration;

        /* _bloodEffect = bloodEffect.GetComponent<Image>();

        r = _bloodEffect.color.r;
        g = _bloodEffect.color.g;
        b = _bloodEffect.color.b;
        a = _bloodEffect.color.a;

        a = 255; */

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
        if(other.gameObject.layer == LayerMask. NameToLayer("player"))
        {
            
            Debug.Log("Me hago danyo");

            //a += 0.1f;
            //_bloodEffect.color.a = a;
        } 

        //a = Mathf.Clamp(a, 0, 1f);

        //ChangeColor();
    }


    /* private void ChangeColor()
    {
        Color c = new Color(r,g,b,a);
        _bloodEffect.color = c;
    } */ 

    void BorrarBala()
    {
        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0)
        {
            Destroy (gameObject, despawn);
        }
    }

}
