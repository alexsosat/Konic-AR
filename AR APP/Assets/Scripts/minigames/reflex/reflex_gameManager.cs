using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class reflex_gameManager : MonoBehaviour
{

    [Header("Gameplay Manager")]
    public FallingCard[] fallingCards;
    public Image currentSprite;
    private FallingCard currentFallingCard;
    private float streak = 0;
    private float streakBonus = 1;

    [Header("Sound Manager")]
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    private AudioSource audioManager;

    [Header("UI Manager")]
    public TextMeshProUGUI streakBonusText;
    public GameObject slider;

    [Header("Win Manager")]
    public AudioClip winSound;
    public GameObject gameArea;
    public GameObject winArea;




    // Start is called before the first frame update
    void Start()
    {
        audioManager = gameObject.GetComponent<AudioSource>();
        SetNewSprite();
    }


    public void CheckCorrectOption(int buttonOption)
    {
        if (buttonOption == currentFallingCard.correctIndex)
        {
            audioManager.PlayOneShot(correctSound);
            slider.GetComponent<ProgressBar>().Progress(0.02f * streakBonus);
            streak++;
            if (streak % 3 == 0)
            {
                streakBonus++;
                streakBonusText.text = 'X' + streakBonus.ToString();
            }
        }
        else
        {
            audioManager.PlayOneShot(incorrectSound);
            slider.GetComponent<ProgressBar>().usedHint(0.02f);
            streak = 0;
            streakBonus = 1;
            streakBonusText.text = 'X' + streakBonus.ToString();
        }
        CheckWin();
        SetNewSprite();
    }

    private void SetNewSprite()
    {
        int n = Random.Range(0, 4);
        currentFallingCard = fallingCards[n];
        currentSprite.sprite = fallingCards[n].modelSprite;
    }

    private void CheckWin()
    {
        if (slider.GetComponent<Slider>().value >= 1)
        {
            GetComponent<simpleCountDown>().pause();
            audioManager.PlayOneShot(winSound);
            gameArea.SetActive(false);
            winArea.SetActive(true);
        }
    }

}
