using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JugadorInteracciones : MonoBehaviour
{

    private Animator animador;

    private Rigidbody2D jugador;

    public GameObject barraVida;

    private float tiempoEspera = 2f;

    public Text textCantEstrellas;

    public int cantEstrellas = 0;
    public int maxEstrellas = 0;
    

    public int vidaActual;
    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
        jugador = GetComponent<Rigidbody2D>();
        vidaActual = 7;
        barraVida.GetComponent<BarraVidaScript>().SetVidaMax(7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Vida"))
        {
            
        }
        if(colision.CompareTag("Enemigo"))
        {

            Danio(3);
            
            if(vidaActual <= 0)
            {
                GuardarPuntaje(cantEstrellas);
                Muerte();
            }
        }
        if(colision.CompareTag("Perseguidor"))
        {
            GuardarPuntaje(cantEstrellas);
            Muerte();
        }
        if(colision.CompareTag("Estrella"))
        {
            Destroy(colision.gameObject);
            cantEstrellas++;
            textCantEstrellas.text = "Estrellas: " + cantEstrellas;

        }
    }

    private void Muerte()
    {
        jugador.bodyType = RigidbodyType2D.Static;
        animador.SetTrigger("Muerte");
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void Danio(int danio)
    {
        vidaActual = vidaActual - danio;
        barraVida.GetComponent<BarraVidaScript>().SetVida(vidaActual);
    }

    private void GuardarPuntaje(int cantidad)
    {
        if(cantidad > maxEstrellas)
        {
            maxEstrellas = cantidad;
            PlayerPrefs.SetInt("puntajeMax", maxEstrellas);
        }
    }

    private void MostrarVida()
    {
        barraVida.SetActive(true);
        if(Time.time >= tiempoEspera)
        {

        }

    }

    private void RegresarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
