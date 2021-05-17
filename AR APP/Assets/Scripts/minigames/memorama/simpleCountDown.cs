using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class simpleCountDown : MonoBehaviour
{
    public float tiempo_Turno;
    public static float tiempo_actual;

    public GameObject gameArea;
    public GameObject loosePanel;
    public TextMeshProUGUI countdown;

    public AudioSource audioManager;
    public AudioClip looseSound;

    private void Start()
    {
        tiempo_actual = tiempo_Turno;

    }


    void Update() //se actualiza el tiempo restante para el usuario y al llegar a 0 que ejecute el método descrito
    {
            tiempo_actual -= 1 * Time.deltaTime;
            if ((int)tiempo_actual <= 0 && gameArea.activeInHierarchy)
            {
                audioManager.PlayOneShot(looseSound);
                gameArea.SetActive(false);
                loosePanel.SetActive(true);

            }

        countdown.text = ((int)tiempo_actual >= 0)?((int)tiempo_actual).ToString():"0";

    }

    public void pause()
    {
        Time.timeScale = 0;
    }
    public void resume()
    {
        Time.timeScale = 1f;
    }
}
