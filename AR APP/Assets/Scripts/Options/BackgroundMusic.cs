using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: Este es el código implementado para que la música de fondo se siga reproduciendo a pesar del cambio de escenas
 * Versión: 1.0
 */

public class BackgroundMusic : MonoBehaviour
{

    private static BackgroundMusic instance = null;
    GameObject controller;
    BackgroundMusicToggler bgtoggle;
    public static BackgroundMusic Instance
    {
        get {
            return instance;
        }
    }


    private void Awake() //En esta sección se comprueba la instancia de la música de fondo y elimina las instancias en exceso al recargar la escena principal
    {
        if(instance!=null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        controller = GameObject.Find("Buttons");
        bgtoggle = controller.GetComponent<BackgroundMusicToggler>();
    }

    private void Update() //Sección la cual silencia la musica
    {
        if (bgtoggle.getToggler() == true)
        {
            this.gameObject.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            this.gameObject.GetComponent<AudioSource>().mute = true;
        }
    }


}
