using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manejadorDeEscena : MonoBehaviour
{
    public GameObject jugador;
    public GameObject menuPrincipal;
    public GameObject stick;
    // Start is called before the first frame update
    void Start()
    {
        menuPrincipal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesactivaMenuPrincipal ()
    {
        menuPrincipal.SetActive(false);
        stick.SetActive(true);
        
    }

    
}
