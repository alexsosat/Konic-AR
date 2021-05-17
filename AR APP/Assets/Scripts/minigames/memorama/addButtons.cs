using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addButtons : MonoBehaviour
{
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;

    private void Awake()
    {
     for(int i = 0; i < 8; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = i.ToString();
            button.transform.SetParent(puzzleField, false);
        }   
    }
}
