using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: En este código va la lógica detrá del aumento de niveles de la computadora 
 * Versión: 1.0
 */
public class LevelManager : MonoBehaviour
{
    
    private Text level;

    private void Start()
    {
        
        
        level = gameObject.GetComponentInChildren<Text>();
    }

    public void Level() // método utilizado para darle a la computadora el nivel por defecto al abrir la tabla de niveles
    {
        Manager.Ailevel = 1;
    }

    public void increaseLevel() //método utilizado para incrementar el nivel de la computadora por medio de botones en pantalla
    {
        if (Manager.Ailevel < 5)
        {
            Manager.Ailevel++;
        }
    }

    public void reduceLevel() //método utilizado para reducir el nivel de la computadora por medio de botones en pantalla
    {
        if (Manager.Ailevel > 1)
        {
            Manager.Ailevel--;
        }
    }

     void Update() //se actualiza el nivel de la computadora en la pantalla para que el usuario pueda ver el nivel de la computadora actual
    {
        level.text = "Nivel: " + Manager.Ailevel;    
    }

}
