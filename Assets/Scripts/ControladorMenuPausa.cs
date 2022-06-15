using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenuPausa : MonoBehaviour
{
    public static bool juegoPausado = false;

    public GameObject menuPausaIU;

    public GameObject musica;

    public GameObject cantMonedas;

    private void Start(){

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(juegoPausado){
                Reanudar();
            }else{
                Pausar();
            }
        }
    }

    public void Reanudar(){
        musica.GetComponent<AudioSource>().Play();
        cantMonedas.SetActive(true);
        menuPausaIU.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    private void Pausar(){
        musica.GetComponent<AudioSource>().Pause();
        menuPausaIU.SetActive(true);
        cantMonedas.SetActive(false);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void Salir(){
        Time.timeScale = 1f;
        juegoPausado = false;
        SceneManager.LoadScene("MenuPrincipal");
    }
}
