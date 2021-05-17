using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: En este código va la lógica para el cambio de escenas dentro del selector de niveles
 * Versión: 1.0
 */
public class LevelSelect : MonoBehaviour
{
    public AudioSource Fx;
    public AudioClip playFX;
    public Animator transition;


    public void PlayMiniGame(int levelId)
    { //método utilizado para la redirección a la escena escogida por el usuario con el sonido apropiado
        if (Actions.active)
        {
            Fx.PlayOneShot(playFX);
        }
        StartCoroutine(EnterLevel(levelId));
    }



    public IEnumerator EnterLevel(int scene) //Rutina utilizada para darle un desfase al cambio de escena para que le de tiempo al efecto de sonido de reproducirse
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + scene);
    }
}
