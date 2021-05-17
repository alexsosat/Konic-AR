using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: Template del contenido de las preguntas 
 * Versión: 1.0
 */
public class Question 
{
    public string pregunta;
    public int respuesta;
    public string pista;
    public string[] respuestas = new string[4];
    public Sprite reference;
}
