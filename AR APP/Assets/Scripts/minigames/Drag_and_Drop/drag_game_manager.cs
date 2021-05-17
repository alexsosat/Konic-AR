using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class drag_game_manager : MonoBehaviour
{

    private bool[] isDraggable = new bool[4];
    private int correctPositions = 0;
    private int movements = 0;

    [Header("Gameplay manager")]
    public GameObject[] objects;
    public GameObject[] targetObjects;
    public Vector2[] initialPositions;

    

    [Header("Audio manager")]
    public AudioSource soundManager;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioClip winSound;


    [Header("Win manager")]
    public GameObject winPanel;
    public GameObject gameArea;
    

    

    private void Start()
    {
        for (int i = 0; i < initialPositions.Length; i++)
        {
            initialPositions[i] = new Vector2(objects[i].transform.localPosition.x, objects[i].transform.localPosition.y);
        }

        for(int i=0; i< isDraggable.Length; i++)
        {
            isDraggable[i] = true;
        }

        RandomizeObjects();
    }

    void RandomizeObjects()
    {
        List<Vector2> listPositions = new List<Vector2>();


        for (int i = 0; i < initialPositions.Length; i++)
        {
            do
            {
                int index = Random.Range(0, initialPositions.Length);
                if (!listPositions.Contains(initialPositions[index]))
                {
                    listPositions.Add(initialPositions[index]);
                    break;
                }
            } while (true);
        }

        for(int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.localPosition = listPositions[i];
        }

        for(int i=0; i< initialPositions.Length; i++)
        {
            initialPositions[i] = listPositions[i];
        }



    }

    public void DragObject(int i)
    { 
        if(isDraggable[i])
        objects[i].transform.position = Input.mousePosition;
    }

    public void DropObject(int i)
    {
        float distance = Vector3.Distance(objects[i].transform.localPosition, targetObjects[i].transform.localPosition);
       
        if (distance < 10 )
        {
            if (isDraggable[i])
            {
                objects[i].transform.localPosition = targetObjects[i].transform.localPosition;
                isDraggable[i] = false;
                soundManager.PlayOneShot(correctSound);
                correctPositions++;
            }
        }
        else
        {
            objects[i].transform.localPosition = initialPositions[i];
            soundManager.PlayOneShot(incorrectSound);
        }

        movements++;
        winCheck();
    }

    private void winCheck()
    {
        if(correctPositions == objects.Length)
        {
            soundManager.PlayOneShot(winSound);
            this.gameObject.GetComponent<simpleCountDown>().pause();

            TextMeshProUGUI feedback = winPanel.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
            feedback.text = "Te tomó " + movements.ToString() + " intentos";

            gameArea.SetActive(false);
            winPanel.SetActive(true);
        }
    }

}
