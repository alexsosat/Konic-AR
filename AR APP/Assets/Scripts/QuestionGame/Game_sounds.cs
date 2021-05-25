using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: En este código están los sonidos a reproducirse al hacer click en las respuestas de los botones si es correcta o incorrecta la respuesta
 * Versión: 1.0
 */
public class Game_sounds : MonoBehaviour
{

    public AudioSource Fx;
    public AudioClip correct;
    public AudioClip incorrect;
    public AudioClip win;
    public AudioClip loose;

    public void CorrectSound() //método para cuando la respuesta del usuario es correcta reproducir el sonido si escogió previamente escuchar sonidos
    {
        if (EffectSoundsToggler.active)
        {
            Fx.PlayOneShot(correct);
        }
        
    }

    public void IncorrectSound() //método para cuando la respuesta del usuario es incorrecta reproducir el sonido si escogió previamente escuchar sonidos
    {
        if (EffectSoundsToggler.active)
        {
            Fx.PlayOneShot(incorrect);
        }
    }

    public void WinSound() //método para cuando el usuario completó el nivel reproducir el sonido si escogió previamente escuchar sonidos
    {
        if (EffectSoundsToggler.active)
        {
            Fx.PlayOneShot(win);
        }
    }

    public void LooseSound() //método para cuando el usuario perdió el nivel reproducir el sonido si escogió previamente escuchar sonidos
    {
        if (EffectSoundsToggler.active)
        {
            Fx.PlayOneShot(loose);
        }
    }

}
