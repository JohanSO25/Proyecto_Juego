using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorFondo : MonoBehaviour
{

    public float tamanioFondo = 17.66489f;
    
    private float zonaVista = 1.5f;
    private Transform camara;
    private Transform[] capas;
    private int indiceDer;
    private int indiceIzq;

    // Start is called before the first frame update
    private void Start()
    {
        camara = Camera.main.transform;
        capas = new Transform[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            capas[i] = transform.GetChild(i);
        }
        indiceIzq = 0;
        indiceDer = capas.Length-1;
    }

    // Update is called once per frame
    private void Update()
    {
        if(camara.transform.position.x < (capas[indiceIzq].transform.position.x + zonaVista)){
            RepetirIzquierda();
        }

        if(camara.transform.position.x > (capas[indiceDer].transform.position.x - zonaVista)){
            RepetirDerecha();
        }
    }


    private void RepetirIzquierda()
    {
        int ultimoDer = indiceDer;

        capas[indiceDer].position = Vector3.right * (capas[indiceIzq].position.x - tamanioFondo);
        indiceIzq = indiceDer;
        indiceDer--;

        if(indiceDer < 0){
            indiceDer = capas.Length - 1;
        }

    }


    private void RepetirDerecha()
    {
        int ultimoIzq = indiceIzq;

        capas[indiceIzq].position = Vector3.right * (capas[indiceDer].position.x + tamanioFondo);
        indiceDer = indiceIzq;
        indiceIzq++;

        if(indiceIzq == capas.Length){
            indiceIzq = 0;
        }
    }
}
