using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguidorScript : MonoBehaviour
{

    public Transform jugador;
    public float velocidad = 1.5f;
    private Rigidbody2D cuerpo;
    private Vector2 movimiento;
    // Start is called before the first frame update
    void Start()
    {
        cuerpo = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direccion = jugador.position - transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        cuerpo.rotation = angulo;
        direccion.Normalize();
        movimiento = direccion;
        //cuerpo.MovePosition(transform.position + ( jugador.position * velocidad * Time.deltaTime));
        Movimiento(movimiento);
    }

    void Movimiento(Vector2 direccion)
    {
        cuerpo.MovePosition((Vector2)transform.position + (direccion * velocidad * Time.deltaTime));
    }
}
