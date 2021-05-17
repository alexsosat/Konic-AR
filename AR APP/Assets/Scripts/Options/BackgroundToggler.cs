using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: Código cuya función es el de cambiar el valor de la variable bg y devolverla con un getter para la silenciación de la música de fondo
 * Versión: 1.0
 */

public class BackgroundToggler : MonoBehaviour
{
    public static bool bg = true;

    public void toggler()
    {
        bg = !bg;
       
    }

    public bool getToggler()
    {
        return bg;
    }
}
