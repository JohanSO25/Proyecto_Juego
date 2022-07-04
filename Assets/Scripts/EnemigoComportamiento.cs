using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoComportamiento : MonoBehaviour
{

    public float velocidad;
    public float distancia;
    //private bool mueveDerecha = true;
    public Transform detectaPiso;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // No se logró implementar correctamente el movimiento de enemigos
    /*void FixedUpdate()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);

        RaycastHit2D infoPiso = Physics2D.Raycast(detectaPiso.position, Vector2.down, distancia);

        if(infoPiso.collider == false)
        {
            if(mueveDerecha == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                mueveDerecha = false;
            }else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                mueveDerecha = true;
            }
        }
    }*/
}
