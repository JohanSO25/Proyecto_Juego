using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaScript : MonoBehaviour
{

    public Slider slider;


    public void SetVidaMax(int vida)
    {
        slider.maxValue = vida;
        slider.value = vida;
    }

    public void SetVida(int vida) 
    { 
        slider.value = vida;
    }
}
