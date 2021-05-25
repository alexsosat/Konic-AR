using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: En este código van los métodos de los botones para los cambios de escena así como también el del sonido de los botones
 * Versión: 1.0
 */

public class Navigator : MonoBehaviour
{
    public AudioSource Fx;
    public AudioClip clickFx;
    public Animator transition;
    
    public void goBack() //método utilizado para el cambio de escena hacia atras
    {
        if (EffectSoundsToggler.active)
        {
            Fx.PlayOneShot(clickFx);
        }
        StartCoroutine(ChangeSceneAnimation(SceneManager.GetActiveScene().buildIndex - 1));
    }

   

    public void goTo(int sceneIndex) //método para el cambio de escena por index
    {
        if (EffectSoundsToggler.active)
        {
            Fx.PlayOneShot(clickFx);
        }
        StartCoroutine(ChangeSceneAnimation(sceneIndex));
    }

    public void Restart()
    {
        if (EffectSoundsToggler.active)
        {
            Fx.PlayOneShot(clickFx);
        }
        StartCoroutine(ChangeSceneAnimation(SceneManager.GetActiveScene().buildIndex));
    }


    public IEnumerator ChangeSceneAnimation(int sceneIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneIndex);
    }

}
