using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scripPrueba2 : MonoBehaviour
{
    Rigidbody rb;
    float velocidad = 50;
    public float vectorX;
    public float vectorY;
    public Joystick stick;
    bool stikActivo=false;

    // raycastCamara

    
    public Camera Camara;

    [SerializeField] private string[] ParedDesactivada ;
    List<GameObject> ParedDesactivadaList = new List<GameObject>();

    // stick invertidor 
    public float sentido = 0;

    // line render 

    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (sentido == 0)
        {
            vectorX = stick.Vertical * 1;

            vectorY = stick.Horizontal * -1;
        }
        else if (sentido == 90)
        {
            vectorX = stick.Horizontal * -1;

            vectorY = stick.Vertical * -1;
        }
        else if (sentido == -90)
        {
            vectorX = stick.Horizontal * 1;

            vectorY = stick.Vertical * 1;
        }
        else if (sentido == 180)
        {
            vectorX = stick.Vertical * -1;

            vectorY = stick.Horizontal * 1;
        }
        // ray cast 
       
        RaycastHit hit;
        if (Physics.Raycast(transform.position, new Vector3(vectorX, 0, vectorY), out hit, 100f))
        {


        }
        Debug.DrawRay(transform.position, new Vector3(vectorX, 0, vectorY) * 20f, Color.red);
        lineRenderer.SetPosition(0, transform.position);

        lineRenderer.SetPosition(1, transform.position + new Vector3(vectorX, 0, vectorY) * 20);
        /// 

      


        RaycastHit paredes;
        

        if (Physics.Raycast( Camara.transform.position,transform.position- Camara.transform.position, out paredes, 1000f))
        {
            if (paredes.transform.name!="jugador" && paredes.transform.tag != "CuboDerecho"&& paredes.transform.tag != "CuboIzquierdo"&& paredes.transform.tag != "Atras" && paredes.transform.tag != "ZonaMuerte")
            {
                paredes.transform.gameObject.GetComponent<Renderer>().enabled = false;

                //ParedDesactivada = paredes.transform.gameObject;
                //ParedDesactivada = new [ paredes.transform.gameObject.name];
                //ParedDesactivadaList.Add(paredes.transform.gameObject);
                if (!ParedDesactivadaList.Contains(paredes.transform.gameObject))
                {
                    ParedDesactivadaList.Add(paredes.transform.gameObject);
                }
                
               
            }
            else if (paredes.transform.name == "jugador"|| paredes.transform.tag== "CuboDerecho"|| paredes.transform.tag == "CuboIzquierdo"|| paredes.transform.tag == "Atras")
            {
                for (int n = 0; n < ParedDesactivadaList.Count; n++)
                {
                    ParedDesactivadaList[n].gameObject.GetComponent<Renderer>().enabled = true;
                    ParedDesactivadaList.Remove(ParedDesactivadaList[n].gameObject);
                }
                //ParedDesactivada.gameObject.GetComponent<Renderer>().enabled = true;

            }

        }
       
        Debug.DrawRay(Camara.transform.position, transform.position - Camara.transform.position, Color.red);
        
    }

    public void DisparaPelota ()
    {
        rb.AddForce(new Vector3(vectorX, 0, vectorY) * velocidad, ForceMode.Impulse);

    }

    public void desactivaStick()
    {
        stick.gameObject.SetActive(false);
        Invoke("activaStick",3f);
    }
    public void activaStick()
    {
        stikActivo = true;
    }
   
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "suelo" && stikActivo)
        {
            stick.gameObject.SetActive(true);
            stikActivo = false;
        }
    }
}
