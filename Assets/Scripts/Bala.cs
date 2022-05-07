using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    //Elimina a los enemies con la layer Enemy y genera particulas de sangre
    public float despawn = 5f;

    public float despawnSangre = 2f;

    public Transform balaMuzzle;

    public GameObject ParticulaSangre;

    public GameObject SonidoMuerte;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemigo"))
        {
            GameObject ParticulaClone =
                Instantiate(ParticulaSangre,
                other.gameObject.transform.position + new Vector3(0, 1.3f, 0),
                Quaternion.Euler(balaMuzzle.forward));
            Destroy (ParticulaClone, despawnSangre);

            Destroy(other.gameObject, despawn);

            Instantiate(SonidoMuerte);
        }
    }
}
