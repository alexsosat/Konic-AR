using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: En este código se aplica la lógica para el tiempo limite que el usuario tendrá para responder las preguntas del programa
 * Versión: 1.0
 */
public class Countdown : MonoBehaviour
{
    public float tiempo_Turno;
    public static float tiempo_actual;
    public TextMeshProUGUI countdown;

    private void Start()
    {
        tiempo_actual = tiempo_Turno;
        
    }

   
    void Update() //se actualiza el tiempo restante para el usuario y al llegar a 0 que ejecute el método descrito
    {
        if (tiempo_actual <= tiempo_Turno)
        {
            tiempo_actual -= 1*Time.deltaTime;
            if((int) tiempo_actual == 0)
            {
                
                gameObject.GetComponent<Manager>().selectAnswer(4);
               
            }
        }
        countdown.text = ((int)tiempo_actual).ToString();
        
    }

    public void pause()
    {
        Time.timeScale = 0;
    }
    public void resume()
    {
        Time.timeScale = 1f;
    }
}
