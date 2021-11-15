using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialNavigator : MonoBehaviour
{
    public TutorialEnabler enabler;
    public TutorialPage[] pages;
    
    
    private int _index = 0;
    
    public void SwitchPage()
    {
        EnablePanel(false);
        _index++;
        if (_index < pages.Length)
        {
            EnablePanel(true);
        }
        else
        {
            gameObject.SetActive(false);
            enabler.setPageOpen();
        }
    }

    private void EnablePanel(bool value)
    {
        pages[_index].panel.SetActive(value);
        if (pages[_index].highlightedGameObject != null)
        {
            pages[_index].highlightedGameObject.SetActive(value); 
        }
    }
}
