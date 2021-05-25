using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: Código el cual en base a los toggler bg y active recrea la escena principal con los respectivos botones para que el usuario vea los valores correctos en pantalla
 * Versión: 1.0
 */

public class MenuSetScene : MonoBehaviour
{
    
    void Awake()
    {

        if (!this.gameObject.GetComponent<EffectSoundsToggler>().getActive())
        {
            transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
        }

        if (!GameObject.Find("Buttons").GetComponent<BackgroundMusicToggler>().getToggler())
        {
            transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        }

    }

   
    
}
