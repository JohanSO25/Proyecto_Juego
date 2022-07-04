using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJugador : MonoBehaviour
{
    [Range(0f, 5f)]
    public float velocidad = 2.5f;

    public float velocidadRotacion = 375f;

    [Range(20f, 150f)]
    public float rotacionMax = 20f;

    private Animator animador;
    private Rigidbody2D rb; 

    private float proximoGiro;

    [Range(0.5f, 2f)]
    public float delayGiro = 0.5f;

    public bool izquierda = false;

    public Vector2 movimiento;


    // Start is called before the first frame update
    private void Start()
    {
        animador = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Se obtiene el valor de los axis del jugador
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        //Se verifica si está yendo a la izquierda o no
        if(Input.GetKeyDown(KeyCode.A)){
            izquierda = true;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            izquierda = false;
        }
        
        Movimiento(hInput, vInput);
        Rotacion(vInput);

        if(Time.time >= proximoGiro){
            
            proximoGiro = Time.time + delayGiro;
            
        } 
        
    }


    private void Movimiento(float hInput, float vInput)
    {
        float auxVelocidad =  velocidad * Time.deltaTime;
        movimiento.x = hInput;
        movimiento.y = vInput;

        //Se acciona el movimiento del jugador
        rb.MovePosition(rb.position + movimiento * velocidad * Time.deltaTime);
        animador.SetFloat("Horizontal", movimiento.x);
        animador.SetFloat("Velocidad", movimiento.sqrMagnitude);
        
    }

    private void Rotacion(float vInput)
    {

        //Se invierte la dirección de rotación al estar a la izquierda
        if(izquierda){
            vInput = -vInput;
        }

        //Se configura la rotación
        float rotacion = vInput * velocidadRotacion * Time.deltaTime;
        float rotacionZ = transform.eulerAngles.z;

        transform.Rotate(0f, 0f, rotacion);
    

        //Límites de rotación
        Vector3 euler = transform.eulerAngles;
        if (euler.z > 180){
            euler.z = euler.z - 360;
        }
        euler.z = Mathf.Clamp(euler.z, -rotacionMax, rotacionMax);
        transform.eulerAngles = euler;
        //print("rotacion: " + rotacion);
    }


}
