using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Sway : MonoBehaviour
{

    private Quaternion originLocalRotation;
    
    public float intensidad = 10f;

    public float tiempo = 10f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        originLocalRotation = transform.localRotation;
    }

    // Update is called once per frame
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
