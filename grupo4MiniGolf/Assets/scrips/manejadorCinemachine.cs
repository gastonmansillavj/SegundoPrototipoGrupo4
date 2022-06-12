using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class manejadorCinemachine : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camaraDisparo;
    [SerializeField] private CinemachineVirtualCamera camaraDisparo2;
    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
        camaraDisparo2.gameObject.SetActive(false);
        //camaraDisparo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "jugador")
        {
            camaraDisparo2.gameObject.SetActive(true);
            camaraDisparo.gameObject.SetActive(false);
            personaje.GetComponent<scripPrueba2>().sentido = 90;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "jugador")
        {
            camaraDisparo.gameObject.SetActive(true);
            
            personaje.GetComponent<scripPrueba2>().sentido = 0;

        }
    }

}
