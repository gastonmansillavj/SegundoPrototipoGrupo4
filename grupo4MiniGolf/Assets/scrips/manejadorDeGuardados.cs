using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manejadorDeGuardados : MonoBehaviour
{
    public float spawnX;
    public float spawnY;
    public float spawnZ;
    int disparos = 0;
    int mejorPuntuacion = 10000000;
    public  Transform[] posicionesSpawn;
    public Vector3 spawnPos;
    public Text contadorDisparo;
    public Text txtMejorPuntuacion;

    public GameObject btnContinue;
    public GameObject btnMenu;
    bool contoladorMenu =false ;

    public Sprite btnCruz;
        

    public GameObject menu;

    public GameObject stick;
    // Start is called before the first frame update
    void Start()
    {
        //CargaSpawn();
        
        transform.position = spawnPos;
        mejorPuntuacion = PlayerPrefs.GetInt("MejorPuntuacion", 100000);
        txtMejorPuntuacion.text = mejorPuntuacion.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        contadorDisparo.text = disparos.ToString();
        txtMejorPuntuacion.text = mejorPuntuacion.ToString();
        if (CargaSpawn() == posicionesSpawn[0].position)
        {
            btnContinue.SetActive(false);
        }
        else
        {
            btnContinue.SetActive(true);
        }

    }
    //
    public void GuardaSpawn()
    {
        PlayerPrefs.SetFloat("ultimoPuntoSpawnX", spawnX);
        PlayerPrefs.SetFloat("ultimoPuntoSpawnY", spawnY);
        PlayerPrefs.SetFloat("ultimoPuntoSpawnZ", spawnZ);
       

    }

    public Vector3 CargaSpawn()
    {
      
       spawnX= PlayerPrefs.GetFloat("ultimoPuntoSpawnX", posicionesSpawn[0].position.x);
       spawnY= PlayerPrefs.GetFloat("ultimoPuntoSpawnY", posicionesSpawn[0].position.y);
       spawnZ=PlayerPrefs.GetFloat("ultimoPuntoSpawnZ", posicionesSpawn[0].position.z);
       spawnPos = new Vector3(spawnX, spawnY, spawnZ);
        return spawnPos;
    }
    public void NuevaPartida ()
    {
        spawnPos = posicionesSpawn[0].position;
        spawnX = posicionesSpawn[0].position.x;
        spawnY = posicionesSpawn[0].position.y;
        spawnZ = posicionesSpawn[0].position.z;
        GuardaSpawn();
        transform.position = spawnPos;
        menu.SetActive(false);
        stick.SetActive(true);
       PlayerPrefs.SetInt("disparos",0);
       disparos = 0;
        btnContinue.SetActive(true);
        

    }

    private void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.name == "Spawn1")
        {
            CargaPosiciones(1);

        }
        if (other.gameObject.name == "Spawn2")
        {
            CargaPosiciones(2);

        }
        if (other.gameObject.name == "Spawn3")
        {
            CargaPosiciones(3);

        }
        if (other.gameObject.name == "Spawn4")
        {
            CargaPosiciones(4);

        }
        if (other.gameObject.name == "Spawn5")
        {
            
            CargaPosiciones(5);

        }
        if (other.gameObject.name == "Spawn5")
        {

            CargaPosiciones(5);

        }

        if (other.gameObject.tag == "ZonaMuerte")
        {

            menu.SetActive(true);

        }
        if (other.gameObject.name == "SpawnFinal")
        {
            mejorPuntuacion = 100000;
            if (disparos<mejorPuntuacion)
            {
                PlayerPrefs.SetInt("MejorPuntuacion",disparos);
            }
           
            menu.SetActive(true);
            btnContinue.SetActive(false);


        }
    }

    public void CargaPosiciones (int nivel)
    {
        spawnPos = posicionesSpawn[nivel].position;
        spawnX = posicionesSpawn[nivel].position.x;
        spawnY = posicionesSpawn[nivel].position.y;
        spawnZ = posicionesSpawn[nivel].position.z;
        GuardaSpawn();
    }

    public void SumaDisparos ()
    {
        disparos++;
        print(disparos);
        PlayerPrefs.SetInt("disparos", disparos);
    }

    
    public void guardaDatos(string nombre,int valor)
    {
        PlayerPrefs.SetInt(nombre, valor);
    }
    public void cargaDatos(int variable ,string nombre, int valor)
    {
        variable = PlayerPrefs.GetInt(nombre, valor);
    }

    public void Continue ()
    {
        
        print(transform.position = CargaSpawn());
        disparos = PlayerPrefs.GetInt("disparos",0);
    }

    public void ActivaBtnMenu ()
    {
       
        if (contoladorMenu == false)
        {
            menu.SetActive(false);
            contoladorMenu = true;
            
        }
        else
        {
            menu.SetActive(true);
            contoladorMenu = false;
            
        }
    }
   

}
