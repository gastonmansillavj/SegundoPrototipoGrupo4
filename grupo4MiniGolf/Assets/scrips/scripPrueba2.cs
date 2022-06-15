using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripPrueba2 : MonoBehaviour
{
    Rigidbody rb;
    float velocidad = 50;
    public float vectorX;
    public float vectorY;
    public Joystick stick;

    // stick invertidor 
    public float sentido = 0;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sentido==0)
        {
            vectorX = stick.Vertical * 1;
            ;
            vectorY = stick.Horizontal * -1;
        }
        else if (sentido== 90)
        {
            vectorX = stick.Horizontal*-1;
            ;
            vectorY = stick.Vertical*-1;
        }
        else if (sentido == -90)
        {

        }
        else if (sentido == -180)
        {

        }






    }

    public void DisparaPelota ()
    {
        rb.AddForce(new Vector3(vectorX, 0, vectorY) * velocidad, ForceMode.Impulse);
        
    }

    public void cambiaVectores()
    {
       
    }
}
