using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEnabler : MonoBehaviour
{
    private static bool[] _wasOpened = new bool[10];
    public GameObject tutorialObject;
    
    // Start is called before the first frame update
    void Start()
    {
        tutorialObject.SetActive(!_wasOpened[SceneManager.GetActiveScene().buildIndex]);
    }

    public void setPageOpen()
    {
        _wasOpened[SceneManager.GetActiveScene().buildIndex] = true;
    } 
    
}
