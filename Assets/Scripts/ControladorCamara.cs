using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    public GameObject jugador;
    public float velocidadCamara = 15f;
    public float offset = -1.5f;
    public bool smoothFollow = false;

    public ControladorJugador controladorJ;

    private float proximoGiro;

    private float delayGiro;

    private Vector2 x;
    
    private void Start(){
        
    }

    private void FixedUpdate()
    {
        delayGiro = jugador.GetComponent<ControladorJugador>().delayGiro;
        //x = jugador.GetComponent<ControladorJugador>().movimiento.x;
        ActualizarPosicion();
    }

    private void ActualizarPosicion()
    {
        if(jugador){
            Vector3 nuevaPos = transform.position;

            //print("izquierda " + jugador.GetComponent<ControladorJugador>().izquierda);
            if(Time.time >= proximoGiro){
                if(jugador.GetComponent<ControladorJugador>().izquierda && offset < 0){
                    // if(jugador.GetComponent<ControladorJugador>().izquierda){
                        offset = -offset;
                    // }else{
                    //     offset = Mathf.Abs(offset);
                    // }
                    proximoGiro = Time.time + delayGiro;
                
                }else{
                    if(jugador.GetComponent<ControladorJugador>().izquierda == false && offset > 0){
                        offset = -offset;
                    }
                }
            }
            

            nuevaPos.x = jugador.transform.position.x - offset;
            nuevaPos.y = jugador.transform.position.y;
            nuevaPos.z = -10f;

            if(!smoothFollow){
                transform.position = nuevaPos;
            }else{
                transform.position = Vector3.Lerp(transform.position, nuevaPos, velocidadCamara * Time.deltaTime);
            }

        }
    }
}
