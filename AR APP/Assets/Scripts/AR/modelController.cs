using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class modelController: MonoBehaviour
{

    public Button[] buttons;
    public Text planeText;
    public Slider[] sliders;
    public Toggle[] ellipseToggles;
    public GameObject[] UI;

    
    public TextMesh slidersValue;
    public TextMesh[] formula;
    public GameObject circunferencePlane;
    public GameObject[] ellipsePlanes;

    private int btnIndex = 0;
    void Start()
    {
        circunferencePlane.active = false;
        TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
        for (int i = 0; i < buttons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            buttons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (btnIndex == 0) {
            CircunferenceFunction();
        }
        if (btnIndex == 1) { 
        }
        if (btnIndex == 2) { 
        }
        
    }
    public void TaskOnClick(int buttonIndex)
    {
        /*foreach (GameObject plane in planes) {
            plane.active = false;
        }*/

        foreach (GameObject util in UI)
        {
            util.SetActive(false);
        }

        if (buttonIndex == 0)
        {
            btnIndex = 0;
            planeText.text = "CIRCUNFERENCIA";
            circunferencePlane.SetActive(true);
            UI[0].SetActive(true);
        }
        else if (buttonIndex == 1)
        {
            //planeText.text = "ELIPSE";
            //planes[1].SetActive(true);
            
        }
        else if (buttonIndex == 2)
        {
            //planeText.text = "PARÁBOLA";
            //planes[2].SetActive(true);
            
        }
        else {
            //planeText.text = "Change";
            //planes[3].SetActive(true);
            
        }
        Debug.Log("You have clicked the button #" + buttonIndex, buttons[buttonIndex]);
    }
    public void CircunferenceFunction () {
        slidersValue.text = System.Math.Pow((sliders[0].value * 5), 2).ToString("0.0");
        circunferencePlane.GetComponent<Transform>().localPosition = new Vector3(0, sliders[0].value, 0);
    }
    public void EllipseFuction() {
        //x=z, z=x, z=y
        int zMax = 0;
        ellipsePlanes[0].GetComponent<Transform>().localPosition = new Vector3(sliders[1].value / 2, sliders[1].value, 0);
        
    }
}
