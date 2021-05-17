using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using TMPro;
/*
 *Autor: Alejandro R. Sosa Trejo 
 * Descripción: En este código está la lógica del juego de preguntas para el usuario
 * Versión: 1.0
 */
public class Manager : MonoBehaviour
{



    [Header("Question Manager")]
    public Question[] questions;
    [SerializeField] private GameObject[] Ans;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private float delay = 1f;
    private static List<Question> unAnswered;
    private Question currentQuestion;
    private int Answer;
    private int AiAnswer;

    [Header("Score Manager")]
    public GameObject PlayerBar;
    public GameObject AiBar;


    static public int Ailevel = 5;

    [Header("UI Manager")]
    public Image img;
    public GameObject pista;

    [Header("Win Manager")]
    public GameObject gameZone;
    public GameObject playerWin;
    public GameObject aiWin;
    private bool win = false;
    private bool one = true;


   

     void Start()
    {
        if(unAnswered == null || unAnswered.Count == 0)
        {
            unAnswered = questions.ToList<Question>();
        }

        setRandomQuestion();
        
    }

    void setRandomQuestion() //método que elige una pregunta del set de preguntas hechas sin repetir preguntas ya hechas
    {
        Countdown.tiempo_actual = gameObject.GetComponent<Countdown>().tiempo_Turno;
        int randomIndex = UnityEngine.Random.Range(0,unAnswered.Count);
        if (unAnswered.Count != 0)
        {
            currentQuestion = unAnswered[randomIndex];

            questionText.text = currentQuestion.pregunta;

            

            for (int i = 0; i < 4; i++)
            {
                Ans[i].GetComponent<Button>().interactable = true;
                Ans[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.respuestas[i];
            }
            pista.GetComponent<Button>().interactable = true;
            img.sprite = currentQuestion.reference;

        }
        else
        {
            unAnswered = questions.ToList<Question>();
        }
        
    }

    public void selectAnswer(int choice) //métdo el cual le da un valor numérico a la respuesta del usuario dependiendo del botón que eligió
    {
        Answer = choice;
        CheckAnswer();

    }

    public void selectHint() //método que despliega la pista para el usuario y lo penaliza en su puntuación
    {
        pista.GetComponentInChildren<Text>().text = currentQuestion.pista;
        PlayerBar.GetComponent<ProgressBar>().usedHint(0.10f);
    }

    IEnumerator Transition() //método que le da un delay entre la respuesta del usuario y la siguiente pregunta para procesos de feedback
    {
        yield return new WaitForSeconds(delay);
        unAnswered.Remove(currentQuestion);
        if (!win)
        {
            AiTurn();
            yield return new WaitForSeconds(delay / 2);
            setRandomQuestion();
        }
    }

    public void AiTurn() //método el cual contiene la lógica de la computadora para responder la pregunta acorde a su nivel previamente escogido
    {
         AiAnswer = UnityEngine.Random.Range(0,10);
        if(AiAnswer > (10 - Ailevel - 4)) {
            AiBar.GetComponent<ProgressBar>().Progress(0.25f);
            gameObject.GetComponent<Game_sounds>().CorrectSound();
        }
        else
        {
            gameObject.GetComponent<Game_sounds>().IncorrectSound();
        }

    }

    IEnumerator showCorrectAnswer() //método que despliega el feedback de la respuesta correcta de la pregunta en base a si contestó bien o mal el usuario
    {
        if (currentQuestion.respuesta == Answer)
        {
            Ans[Answer].GetComponent<Image>().color = new Color32(6, 241, 0, 100);
            yield return new WaitForSeconds(1f);
            Ans[Answer].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            Ans[Answer].GetComponent<Image>().color = new Color32(255, 0, 0, 100);
            for (int a = 0; a < 4; a++)
            {
                Ans[currentQuestion.respuesta].GetComponent<Image>().color = Color.Lerp(new Color32(255, 255, 255, 255), new Color32(6, 241, 0, 100), Time.time);//new Color32(6, 241, 0, 100);
                yield return new WaitForSeconds(0.55f);
                Ans[currentQuestion.respuesta].GetComponent<Image>().color = Color.Lerp(new Color32(6, 241, 0, 100), new Color32(255, 255, 255, 255), Time.time);//new Color32(255, 255, 255, 255);
                yield return new WaitForSeconds(0.55f);
            }
            Ans[Answer].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }

    public void CheckAnswer() //método de validación de la respuesta del usuario con la respuesta real de la pregunta hecha a él
    {
        for (int i = 0; i < 4; i++)
        {
            Ans[i].GetComponent<Button>().interactable = false;
        }
        pista.GetComponent<Button>().interactable = false;
        pista.transform.GetChild(0).gameObject.SetActive(false);
       
        if (currentQuestion.respuesta == Answer)
        {
            Debug.Log("Respuesta Correcta");
            PlayerBar.GetComponent<ProgressBar>().Progress(0.25f);
            gameObject.GetComponent<Game_sounds>().CorrectSound();
        }
        else
        {
            Debug.Log("Respuesta incorrecta");
            gameObject.GetComponent<Game_sounds>().IncorrectSound();
        }

        if ((int)Countdown.tiempo_actual != 0)
        {
            StartCoroutine(showCorrectAnswer());
        }
        Countdown.tiempo_actual = 99;
        StartCoroutine(Transition());
    }

    private void Update() //chequeó de las puntaciones de el jugador y la computadora y terminar el proceso de juego si uno llega a la cima
    {
        if (PlayerBar.GetComponent<Slider>().value == 1 && one)
        {
            gameObject.GetComponent<Game_sounds>().WinSound();
            playerWin.GetComponentInChildren<TextMeshProUGUI>().text = "Felicidades completaste el nivel " + Ailevel;
            gameZone.SetActive(false);
            playerWin.SetActive(true);
            one = false;
            win = true;
        }
        else if(AiBar.GetComponent<Slider>().value == 1 && one)
        {
            gameObject.GetComponent<Game_sounds>().LooseSound();
            gameZone.SetActive(false);
            aiWin.SetActive(true);
            one = false;
            win = true;
        }
    }

}
