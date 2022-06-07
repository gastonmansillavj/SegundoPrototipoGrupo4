using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jugadorPrincipal : MonoBehaviour
{
    
    public float velocidad = 2f;
    public float angulo = 0;
    bool disparo = false;

    public GameObject jugador;

    Vector3 posicionInicial;

    Rigidbody rb;
    // vectores en x
    float vx;
    float vy;

    // gizmos 
    public float gizmosX;
    public float gizmosY;

    public LineRenderer lineRenderer;


    // estado botones 

    public bool botonDer = false;
    public bool botonIzq = false;

    // boton disparo

    public Button lanza;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }

    private void FixedUpdate()


    {
       
      

        transform.eulerAngles = new Vector3(0,-angulo+90,270);


        if ((Input.GetKey(KeyCode.Space)) && rb.velocity == new Vector3(0,0,0) && !disparo )
        {

            disparaBola();
          
         
        }
        
        
        else if (disparo)
        {
           
            Invoke("reacomoda",6);


        }
        

    if (botonDer)
        {
            sumaAngulo();
        }
    else if (botonIzq)
        {
            restaAngulo();
        }
     
    RaycastHit hit;
       
            if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit,1000f)) {
            

        }
            else
        {
      
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000f, Color.yellow);
        Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.forward) * 1000f);
        
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit.point);


    }
    private void OnDrawGizmos()
    {
       // Gizmos.color = Color.red;
       //Gizmos.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * 1000f);
       // Gizmos.DrawLine(transform.position, transform.TransformDirection(Vector3.forward) * 1000f);
    }
   
    // Update is called once per frame
    void Update()
    {
       
    }

    void reacomoda ()
    {
      //  Destroy(gameObject);
       // Instantiate(jugador);
        //jugador.transform.position = posicionInicial;


    }

    public void sumaAngulo ()
    {
        angulo -= 0.2f;
       
    }
    public void restaAngulo()
    {
        angulo +=0.2f;
       
       
    }

    public void activaBotonDer ()
    {
        botonDer=true;
    }

    public void desActivaBotonDer()
    {
        botonDer = false;
    }

    public void activaBotonIzq()
    {
        botonIzq = true;
    }

    public void desActivaBotonIzq()
    {
        botonIzq = false;
    }

    public void disparaBola()
    {
        rb.AddForce(transform.forward * velocidad , ForceMode.Impulse);
        disparo = true;

    }


}
