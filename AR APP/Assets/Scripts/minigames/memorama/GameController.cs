using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
   
    public Sprite[] puzzles;
    public Sprite bgImage;

    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();

    public AudioSource audioSound;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioClip winSound;

    public GameObject gameArea;
    public GameObject winPanel;

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    private void Awake()
    {
        
    }

    private void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Randomizer(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i=0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());

        }
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for(int  i =0; i < looper; i++)
        {
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void AddListeners()
    {

            foreach(Button btn in btns)
            {
                btn.onClick.AddListener(()=>PickAPuzzle());
            }

    }

    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
       

        if (!firstGuess)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];

            btns[firstGuessIndex].gameObject.GetComponent<Button>().interactable = false;
            btns[firstGuessIndex].gameObject.GetComponentInChildren<Text>().enabled = false;

        }
        else if (!secondGuess)
        {
            secondGuess = true;

            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            btns[secondGuessIndex].gameObject.GetComponent<Button>().interactable = false;
            btns[secondGuessIndex].gameObject.GetComponentInChildren<Text>().enabled = false;

            countGuesses++;
            StartCoroutine(checkThePuzzlesMatch());
        }
        
    }

    IEnumerator checkThePuzzlesMatch()
    {
        yield return new WaitForSeconds(0.5f);

        if (firstGuessPuzzle == secondGuessPuzzle + "_p" || firstGuessPuzzle + "_p" == secondGuessPuzzle)
        {
            audioSound.PlayOneShot(correctSound);
            yield return new WaitForSeconds(0.75f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            checkGameFinished();
        }
        else
        {
            audioSound.PlayOneShot(incorrectSound);
            yield return new WaitForSeconds(0.75f);

            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;

            btns[firstGuessIndex].gameObject.GetComponent<Button>().interactable = true;
            btns[secondGuessIndex].gameObject.GetComponent<Button>().interactable = true;

            btns[firstGuessIndex].gameObject.GetComponentInChildren<Text>().enabled = true;
            btns[secondGuessIndex].gameObject.GetComponentInChildren<Text>().enabled = true;


        }
        yield return new WaitForSeconds(0.5f);

        firstGuess = secondGuess = false;
    }

    void checkGameFinished()
    {
        countCorrectGuesses++;
        if(countCorrectGuesses == gameGuesses && gameArea.activeInHierarchy)
        {
            audioSound.PlayOneShot(winSound);
            TextMeshProUGUI feedback = winPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            feedback.text = "Te tomó " + countGuesses + " intentos";

            this.gameObject.GetComponent<simpleCountDown>().pause();

            gameArea.SetActive(false);
            winPanel.SetActive(true);
        }
    }

    void Randomizer(List<Sprite> list)
    {
        for(int i=0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

}
