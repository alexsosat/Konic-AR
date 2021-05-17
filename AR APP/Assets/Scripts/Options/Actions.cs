using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: En este código van los métodos de los botones para los cambios de escena así como también el del sonido de los botones
 * Versión: 1.0
 */

public class Actions : MonoBehaviour
{
    public AudioSource Fx;
    public AudioClip clickFx;
    public static bool active = true;
    public Animator transition;
    public void PlayGame(){ //método utilizado para el cambio de escena hacia adelante
        if (active)
        {
            Fx.PlayOneShot(clickFx);
        }
        StartCoroutine(ChangeScene());
  }

    public IEnumerator ChangeScene() //Rutina utilizada para darle un desfase al cambio de escena para que le de tiempo al efecto de sonido de reproducirse
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnGame() //método utilizado para el cambio de escena hacia atras
    {
        if (active)
        {
            Fx.PlayOneShot(clickFx);
        }
        StartCoroutine(ChangeSceneBack());
    }

    public IEnumerator ChangeSceneBack()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }

    public void ReturnToGame(int sc) //método utilizado para el cambio de escena hacia atras
    {
        if (active)
        {
            Fx.PlayOneShot(clickFx);
        }
        StartCoroutine(ChangeSceneToBack(sc));
    }

    public IEnumerator ChangeSceneToBack(int sc)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sc);
    }

    public void sound_effects_toggle() //método utilizado para cambiar el valor de la variable active para que dejar de reproducir efectos de sonido
    {
        active = !active;
    }

    public bool getActive() //Getter de la variable active
    {
        return active;
    }

    public void PlayAR()
    { //método utilizado para el cambio de escena hacia adelante
        if (active)
        {
            Fx.PlayOneShot(clickFx);
        }
        StartCoroutine(ChangeToAR());
    }

    public IEnumerator ChangeToAR() //Rutina utilizada para darle un desfase al cambio de escena para que le de tiempo al efecto de sonido de reproducirse
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("PanelMenu");
    }

}
