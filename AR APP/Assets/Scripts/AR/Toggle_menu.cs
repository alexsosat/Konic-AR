using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_menu : MonoBehaviour
{
    public GameObject menuObject;
    private bool _isOpen = true;
    
    public void ToggleMenu()
    {
        menuObject.SetActive(!_isOpen);
        _isOpen = !_isOpen;
    }
}
