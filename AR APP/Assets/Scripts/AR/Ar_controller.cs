using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using TMPro;
/*
 *Autores: Alejandro R. Sosa Trejo & Astrid Yamilet Villazul Longi 
 * Descripción: El código se encarga del movimiento de los planos circunferencia y ellipse, los cuales se activan dependiento de los botones y cambian según la posición del slider determinado
 * Versión: 1.0
 */

public class Ar_controller : MonoBehaviour
{
    [Header("Title")]
    public TextMeshProUGUI sectionText;


    [Header("General UI")]
    public Button[] buttons;
    public GameObject[] planes;
    public GameObject[] texts;
    public GameObject[] UI;



    private int state = 0;

    [Header("Circunference")]
    public TextMeshProUGUI circleEquationText;
    public Slider circleSlider;


    [Header("Ellipse")]
    public TextMeshProUGUI ellipseEquationText;
    public Slider[] ellipseSliders;

    [Header("Parabole")]
    public TextMeshProUGUI paraboleEquationText;
    public Slider paraboleSlider;

    [Header("Hyperbole")]
    public TextMeshProUGUI hyperboleEquationText;
    public Slider[] hyperboleSliders;


    void Start()
    {


        TextMeshPro t = (TextMeshPro)gameObject.GetComponent(typeof(TextMeshPro));

        for (int i = 0; i < buttons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            buttons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            Circunferencia();
        }
        if (state == 1)
        {
            Ellipse();
        }
        if (state == 2)
        {
            Parabola();
        }
        if (state == 3)
        {
            Hiperbola();
        }
    }


    public void TaskOnClick(int buttonIndex)
    {

        foreach (GameObject plane in planes)
        {
            plane.SetActive(false);
        }

        foreach (GameObject util in UI)
        {
            util.SetActive(false);
        }

        foreach (GameObject util in texts)
        {
            util.SetActive(false);
        }
        if (buttonIndex == 0)
        {
            sectionText.text = "CIRCUNFERENCIA";
            state = 0;
            planes[0].SetActive(true);
            UI[0].SetActive(true);
            texts[0].SetActive(true);
        }
        else if (buttonIndex == 1)
        {
            sectionText.text = "ELIPSE";
            state = 1;
            planes[1].SetActive(true);
            UI[1].SetActive(true);
            texts[1].SetActive(true);
        }
        else if (buttonIndex == 2)
        {
            sectionText.text = "PARÁBOLA";
            state = 2;
            planes[2].SetActive(true);
            UI[2].SetActive(true);
            texts[2].SetActive(true);
        }
        else if (buttonIndex == 3)
        {
            sectionText.text = "HIPÉRBOLA";
            state = 3;
            planes[3].SetActive(true);
            UI[3].SetActive(true);
            texts[3].SetActive(true);
        }

    }


    public void Circunferencia()
    {
        // x + y = r²
        float sliderValue = circleSlider.value;

        double r = Math.Pow(sliderValue * 5, 2);

        circleEquationText.text = "x + y = " + r.ToString("0.0");

        planes[state].GetComponent<Transform>().localPosition = new Vector3(0, sliderValue, 0);

    }
    public void Ellipse()
    {
        String formulaTxt = "";

        //(1 − 𝑚²)𝑥² + 2𝑘𝑚𝑥 + 𝑦² − 𝑘² = 0
        double k = ellipseSliders[0].value;
        double m = ellipseSliders[1].value;
       

        formulaTxt += (1 - Math.Pow(m, 2)).ToString("0.0000") + " x ";          // (1 - m²)x²
        if ((2 * k * m) < 0)
            formulaTxt += "- ";
        else
            formulaTxt += "+ ";
        formulaTxt += Math.Abs(2 * k * m).ToString("0.0000") + " x +";           // 2kmx
        formulaTxt += "y - ";                                                   //y² -
        formulaTxt += Math.Pow(k, 2).ToString("0.0000") + " = 0";               //k²

        ellipseEquationText.text = formulaTxt;


        double val = Math.Round(ellipseSliders[1].value * 20) / 20;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, (float)val * 45));
        planes[state].GetComponent<Transform>().localRotation = rotation;
        planes[state].GetComponent<Transform>().localPosition = new Vector3(0, ellipseSliders[0].value, 0);

    }

    public void Parabola()
    {
        String formulaTxt = "y  = ";

        //y² = -2k ( x - k/2)
        double k = paraboleSlider.value;


        formulaTxt += (-2 * k).ToString("0.0000") + " ( x ";         //-2k
        if ((k / 2) >= 0)
            formulaTxt += "+ ";
        else
            formulaTxt += "- ";
        formulaTxt += Math.Abs(k).ToString("0.0000") + " / 2 )";         //k/2
        paraboleEquationText.text = formulaTxt;


        planes[state].GetComponent<Transform>().localPosition = new Vector3(0, (float)0.7, (float)(k - .5));
    }

    public void Hiperbola()
    {
        String formulaTxt = "";

        //(1 - m²)x² + 2kmx + y² - k² = 0
        double m = hyperboleSliders[0].value;
        double k = hyperboleSliders[1].value;
        double km = 2 * k * m;

        formulaTxt += (1 - Math.Pow(m, 2)).ToString("0.0000") + " x ";          // (1 - m²)x²
        if ((2 * k * m) >= 0)
            formulaTxt += "+ ";
        else
            formulaTxt += "- ";
        formulaTxt += Math.Abs(2 * k * m).ToString("0.0000") + " x +";           // 2kmx
        formulaTxt += "y - ";                                                   //y² -
        formulaTxt += Math.Pow(k, 2).ToString("0.0000") + " = 0";               //k²

        hyperboleEquationText.text = formulaTxt;


        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, (float)m * 180));
        planes[state].GetComponent<Transform>().localRotation = rotation;
        planes[state].GetComponent<Transform>().localPosition = new Vector3((float)k, 0, 0);
       
        
        //hyperboleEquationValues[0].text = "+ "+ (m * m).ToString("0.0000") + " x +";           // m²
        //if (km >= 0)
        //{
        //    hyperboleEquationValues[1].text = "y  + " + km.ToString("0.0000") + " = 0";    // 2km 
        //}
        //else
        //{
        //    hyperboleEquationValues[1].text = "y  " + km.ToString("0.0000") + " = 0";         // 2km 
        //}
        //hyperboleEquationValues[2].text = (k * k).ToString("0.0000") + " x ";           // k²


    }
}
