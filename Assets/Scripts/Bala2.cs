using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bala2 : MonoBehaviour
{

    public float speed = 8f;
    public float lifeDuration = 2f;
    float lifeTimer;

    public Image bloodEffect;

    private float r;
    private float g;
    private float b;
    private float a;

    void Start()
    {
        lifeTimer = lifeDuration;

        r = bloodEffect.color.r;
        g = bloodEffect.color.g;
        b = bloodEffect.color.b;
        a = bloodEffect.color.a;
    }

    
    void Update()
    {
        lifeTimer -=Time.deltaTime;
        if(lifeTimer <=0)
        {
            gameObject.SetActive(false);
        }

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

            a += 0.1f;

        } 

        a = Mathf.Clamp(a, 0, 1f);

        ChangeColor();
    }

    private void ChangeColor()
    {
        Color c = new Color(r,g,b,a);
        bloodEffect.color = c;
    }

}
