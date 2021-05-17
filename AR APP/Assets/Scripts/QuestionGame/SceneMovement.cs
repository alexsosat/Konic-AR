using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: código de redireccionamientos a las siguientes páginas una vez concluído el juego
 * Versión: 1.0
 */
public class SceneMovement : MonoBehaviour
{
    public Animator transition;
    public AudioSource Fx;
    public AudioClip clickFx;



    public void Exit()
    {
        if (Actions.active)
        {
            Fx.PlayOneShot(clickFx);
        }
        StartCoroutine(ChangeScene(2));
    }

    

    public void ResetGame()
    { //método utilizado para el cambio de escena hacia adelante
        if (Actions.active)
        {
            Fx.PlayOneShot(clickFx);
        }
        StartCoroutine(ChangeScene(SceneManager.GetActiveScene().buildIndex));
    }

    public IEnumerator ChangeScene(int sceneIndex) //Rutina utilizada para darle un desfase al cambio de escena para que le de tiempo al efecto de sonido de reproducirse
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneIndex);
    }

}
