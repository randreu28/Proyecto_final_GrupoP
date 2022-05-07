using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{

    //Efecto de sangre en pantalla

    public GameObject bloodEffect;

    public float VelRegeneracion = 0.001f;

    [Range(0,1)]
    
    public float Daño = 0.01f;

    private Color blood;

    void Start()
    {
        blood = bloodEffect.GetComponent<Image>().color;
    }

    void FixedUpdate()
    {
        RegenVida();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bala2(Clone)")
        {
            PierdeVida();
        }
    }

    void RegenVida()
    {
        //var blood = bloodEffect.GetComponent<Image>().color;

        blood.a -= VelRegeneracion;

        bloodEffect.GetComponent<Image>().color = blood;
    }

    void PierdeVida()
    {
        //var blood = bloodEffect.GetComponent<Image>().color;

            blood.a += Daño;

            bloodEffect.GetComponent<Image>().color = blood;

            blood.a = Mathf.Clamp(blood.a, 0, 1f);
    }

}
