using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: En este código van los métodos de los botones para los cambios de escena así como también el del sonido de los botones
 * Versión: 1.0
 */

public class EffectSoundsToggler : MonoBehaviour
{
    public static bool active = true;


    public void sound_effects_toggle() //método utilizado para cambiar el valor de la variable active para que dejar de reproducir efectos de sonido
    {
        active = !active;
    }

    public bool getActive() //Getter de la variable active
    {
        return active;
    }

}
