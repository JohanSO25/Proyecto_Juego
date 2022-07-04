using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenuPausa : MonoBehaviour
{
    public static bool juegoPausado = false;

    public GameObject menuPausaIU;

    public GameObject musica;
    public Texture2D cursor;

    public GameObject jugador;

    private void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegoPausado)
            {
                Reanudar();
            }else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        musica.GetComponent<AudioSource>().Play();
        menuPausaIU.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
        Cursor.visible = false;
    }

    private void Pausar()
    {
        musica.GetComponent<AudioSource>().Pause();
        menuPausaIU.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
        Cursor.visible = true;
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        juegoPausado = false;
        GuardarPuntaje(jugador.GetComponent<JugadorInteracciones>().cantEstrellas);
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void GuardarPuntaje(int cantidad)
    {
        if(cantidad > jugador.GetComponent<JugadorInteracciones>().maxEstrellas)
        {
            PlayerPrefs.SetInt("puntajeMax", jugador.GetComponent<JugadorInteracciones>().maxEstrellas);
        }
    }
}
