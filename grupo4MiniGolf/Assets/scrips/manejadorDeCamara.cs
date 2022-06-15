using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manejadorDeCamara : MonoBehaviour
{

    public Vector3 offset;
    public Transform objetivo;
    public float realentizado;
    // Start is called before the first frame update
    void Start()
    {
        objetivo = objetivo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,objetivo.position+offset,realentizado);
    }
}
