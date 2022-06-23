using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class manejadorCinemachine : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camaraDelantera;
    [SerializeField] private CinemachineVirtualCamera camaraDerecha;
    [SerializeField] private CinemachineVirtualCamera camaraIzquierda;
    [SerializeField] private CinemachineVirtualCamera camaraAtras;

   

    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
       camaraDelantera.gameObject.SetActive(true);
        //camaraDisparo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "CuboDerecho")
        {
            camaraDelantera.gameObject.SetActive(false);
            camaraIzquierda.gameObject.SetActive(false);
            camaraAtras.gameObject.SetActive(false);
            camaraDerecha.gameObject.SetActive(true);
            personaje.GetComponent<scripPrueba2>().sentido = 90;

        }
        
        if (other.gameObject.tag == "CuboIzquierdo")
        {
           
            camaraDelantera.gameObject.SetActive(false);
            camaraDerecha.gameObject.SetActive(false);
            camaraAtras.gameObject.SetActive(false);
            camaraIzquierda.gameObject.SetActive(true);
            personaje.GetComponent<scripPrueba2>().sentido = -90;

        }

        if (other.gameObject.tag == "Atras")
        {

            camaraDelantera.gameObject.SetActive(false);
            camaraDerecha.gameObject.SetActive(false);
            camaraIzquierda.gameObject.SetActive(false);
            camaraAtras.gameObject.SetActive(true);
            personaje.GetComponent<scripPrueba2>().sentido = 180;

        }


    }

 

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CuboDerecho"|| other.gameObject.tag == "CuboIzquierdo"|| other.gameObject.tag == "Atras")
        {
           camaraDelantera.gameObject.SetActive(true);
            
            personaje.GetComponent<scripPrueba2>().sentido = 0;

        }
    }
    
}
