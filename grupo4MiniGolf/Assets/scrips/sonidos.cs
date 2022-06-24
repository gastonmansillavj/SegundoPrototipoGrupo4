using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonidos : MonoBehaviour
{
    AudioSource manejadorAudios;
    public AudioClip disparo;
    public AudioClip arrastra;
    public AudioClip puntoDeLLegada;
    public AudioClip puntoDeGuardado;

    // Start is called before the first frame update
    void Start()
    {
        manejadorAudios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puntosDeGuardado"|| other.gameObject.name == "SpawnFinal")
        {
            manejadorAudios.PlayOneShot(puntoDeGuardado);
        }

    }

    public void reproduceDisparo()
    {
        manejadorAudios.PlayOneShot(disparo);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag== "paredes"|| collision.gameObject.tag == "suelo"|| collision.gameObject.tag == "caida")
        {
            
            manejadorAudios.PlayOneShot(disparo);
        }
    }
}
