using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Sway : MonoBehaviour
{
    //Balanceo de la pistola

    private Quaternion originLocalRotation;
    
    public float intensidad = 10f;

    public float tiempo = 10f;
    
    void Start()
    {
        originLocalRotation = transform.localRotation;
    }

    void Update()
    {
        UpdateSway();
    }
  
    private void UpdateSway()
    {
        //pilla input del raton

        float t_xLookInput = Input.GetAxis("Mouse X");
        float t_yLookInput = Input.GetAxis("Mouse Y");

        //calcula la rotacion del arma
        Quaternion t_xAngleAdjustment = Quaternion.AngleAxis(-t_xLookInput * intensidad, Vector3.up);
        Quaternion t_yAngleAdjustment = Quaternion.AngleAxis(t_yLookInput * intensidad, Vector3.right);
        Quaternion t_targerRotation = originLocalRotation * t_xAngleAdjustment * t_yAngleAdjustment;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targerRotation, Time.deltaTime * tiempo);
    }  
}
