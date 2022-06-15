using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenuPrincipal : MonoBehaviour
{

    public GameObject menuAjustes;
    public GameObject menuPrincipal;
    public GameObject menuCargar;

    public void Jugar(){
    	SceneManager.LoadScene("Tuneles");
    }

    public void Cagar(){
        
    }

    public void Ajustes(){
        menuAjustes.SetActive(true);
        menuPrincipal.GetComponent<Animator>().Play("SalidaMenuPrincipal");
        menuAjustes.GetComponent<Animator>().Play("MenuAjustes");
    }

    public void Volver(string inicio){
        if(inicio == "Ajustes"){
            menuAjustes.GetComponent<Animator>().Play("SalidaMenuAjustes");
            menuPrincipal.GetComponent<Animator>().Play("MenuPrincipal");
        }else{
            if(inicio == "Cargar"){

            }
        }
    }
    
    public void Salir(){
        Debug.Log("Saliendo...");
    	Application.Quit();
    }
}
