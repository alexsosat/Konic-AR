using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class reflex_gameManager : MonoBehaviour
{

    [Header("Gameplay manager")]
    public FallingCard[] fallingCards;
    public Image currentSprite;
    private FallingCard currentFallingCard;
    private float streak = 0;
    private float streakBonus = 1;

    [Header("UI manager")]
    public TextMeshProUGUI streakBonusText;
    public GameObject slider;

    [Header("Win manager")]
    private AudioSource audioManager;
    public AudioClip winSound;
    public GameObject gameArea;
    public GameObject winArea;




    // Start is called before the first frame update
    void Start()
    {
        audioManager = gameobject.GetComponent<AudioSource>();
        setNewSprite();
    }


    public void checkCorrectOption(Image buttonSprite)
    {
        if (buttonSprite.sprite.name == currentFallingCard.correctSprite.name)
        {

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
            slider.GetComponent<ProgressBar>().usedHint(0.02f);
            streak = 0;
            streakBonus = 1;
            streakBonusText.text = 'X' + streakBonus.ToString();
        }
        checkWin();
        setNewSprite();
    }

    public void setNewSprite()
    {
        int n = Random.Range(0, 4);
        currentFallingCard = fallingCards[n];
        currentSprite.sprite = fallingCards[n].modelSprite;
    }

    public void checkWin()
    {
        if (slider.GetComponent<Slider>().value >= 1)
        {
            audioManager.PlayOneShot(winSound);
            gameArea.setActive(false);
            winArea.setActive(true);
        }
    }

}
