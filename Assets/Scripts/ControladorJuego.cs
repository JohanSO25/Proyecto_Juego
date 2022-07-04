using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJuego : MonoBehaviour
{
    
    public GameObject perseguidor;

    public GameObject jugador;

    private bool existePerseguidor = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jugador.GetComponent<JugadorInteracciones>().cantEstrellas > 3 && !existePerseguidor)
        {
            Instantiate(perseguidor, new Vector3 (0,0,0), Quaternion.identity);
            existePerseguidor = true;
        }
    }
}
