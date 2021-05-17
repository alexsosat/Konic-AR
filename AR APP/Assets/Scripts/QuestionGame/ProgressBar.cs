using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: En este código está la lógica detrás del aumento de las puntuaciones de el usuario y la computadora para el juego de preguntas
 * Versión: 1.0
 */
public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0;


    public float fillSpeed = 0.5f;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        //GameObject.Find("progressBarAI").GetComponent<ProgressBar>().Progress(1);
        //GameObject.Find("progressBarPlayer").GetComponent<ProgressBar>().Progress(1);
    }



    void Update() //Actualización periódica de la barra de puntuación para darle un efecto más suave a la transición
    {
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }
        else if (slider.value > targetProgress + .01)
        {
            slider.value -= fillSpeed * Time.deltaTime;
        }


    }

    public void Progress(float nProgress) //método el cual aumenta la barra de puntuación en base al número escrito
    {
        targetProgress = slider.value + nProgress;
    }


    public void usedHint(float nProgress) //penalización de puntuación en base a la cantidad escrita
    {
        targetProgress = slider.value - nProgress;
    }

}
