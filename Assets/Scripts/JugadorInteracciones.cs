using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JugadorInteracciones : MonoBehaviour
{

    private Animator animador;

    private Rigidbody2D jugador;
    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
        jugador = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Vida")){
            
        }
        if(colision.CompareTag("Enemigo")){
            Muerte();
        }
    }

    private void Muerte(){
        jugador.bodyType = RigidbodyType2D.Static;
        animador.SetTrigger("Muerte");
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void RegresarMenuPrincipal(){
        SceneManager.LoadScene("MenuPrincipal");
    }
}
