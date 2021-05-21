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


public class modelControlle_Alex : MonoBehaviour
{

    [Header("Title")]
    public Text planeText;


    [Header("General UI")]
    public Button[] buttons;
    public GameObject[] planes;
    public GameObject[] texts;
    public GameObject[] UI;

    

    private int state = 0;

    [Header("Circunference")]
    public TextMeshPro circleEquationValue;
    public Slider circleSlider;


    [Header("Ellipse")]
    public TextMeshPro[] ellipseEquationValues;
    public Slider[] ellipseSliders;

    [Header("Parabole")]
    public TextMeshPro[] paraboleEquationValues;
    public Slider paraboleSlider;

    [Header("Hyperbole")]
    public TextMeshPro[] hyperboleEquationValues;
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
    void Update(){
        if (state == 0){
            Circunferencia();
        }if (state == 1){
            Ellipse();
        }if (state == 2){
            Parabola();
        }if (state == 3){
            Hiperbola();
        }
    }


    public void TaskOnClick(int buttonIndex){
        
        foreach (GameObject plane in planes)
        {
            plane.SetActive(false);
        }

        foreach (GameObject util in UI){
            util.SetActive(false);
        }

        foreach (GameObject util in texts)
        {
            util.SetActive(false);
        }
        if (buttonIndex == 0)
        {
            planeText.text = "CIRCUNFERENCIA";
            state = 0;
            planes[0].SetActive(true);
            UI[0].SetActive(true);
            texts[0].SetActive(true);
        }
        else if (buttonIndex == 1)
        {
            planeText.text = "ELIPSE";
            state = 1;
            planes[1].SetActive(true);
            UI[1].SetActive(true);
            texts[1].SetActive(true);
        }
        else if (buttonIndex == 2)
        {
            planeText.text = "PARÁBOLA";
            state = 2;
            planes[2].SetActive(true);
            UI[2].SetActive(true);
            texts[2].SetActive(true);
        }
        else if (buttonIndex == 3)
        {
            planeText.text = "HIPÉRBOLA";
            state = 3;
            planes[3].SetActive(true);
            UI[3].SetActive(true);
            texts[3].SetActive(true);
        }
        
    }


    public void Circunferencia()
    {
        circleEquationValue.text = Math.Pow(circleSlider.value * 5, 2).ToString("0.0");
        planes[state].GetComponent<Transform>().localPosition = new Vector3(0, circleSlider.value, 0);

    }
    public void Ellipse()
    {
        
        //(1 − 𝑚²)𝑥² + 2𝑘𝑚𝑥 + 𝑦² − 𝑘² = 0
        double k = ellipseSliders[0].value;
        double m = ellipseSliders[1].value;
        double km = 2*k*m;

       
        ellipseEquationValues[0].text = (k*k).ToString("0.0000");            // k²
        ellipseEquationValues[1].text = (1-m*m).ToString("0.0000");          // m²
        if(km<0){
            ellipseEquationValues[2].text = km.ToString("0.0000");          // 2km 
        }else{
            ellipseEquationValues[2].text = "+" + km.ToString("0.0000");    // 2km 
        }
        double val = Math.Round(ellipseSliders[1].value * 20) / 20;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, (float)val * 45));
        planes[state].GetComponent<Transform>().localRotation = rotation;
        planes[state].GetComponent<Transform>().localPosition = new Vector3(0, ellipseSliders[0].value, 0);

    }

    public void Parabola (){
        //y² = -2k ( x - k/2)
        double k = paraboleSlider.value;

        

        paraboleEquationValues[1].text = (-2*k).ToString("0.0000");               //-2k 
        if((k/2)>=0){
            paraboleEquationValues[0].text = "+" + (k / 2).ToString("0.0000");    //k/2
        }else{
            paraboleEquationValues[0].text = (k / 2).ToString("0.0000");          //k/2
        }
        planes[state].GetComponent<Transform>().localPosition = new Vector3(0, (float).5, (float)(k-.5));
    }

    public void Hiperbola(){
        //(1 - m²)x² + 2kmx + y² - k² = 0
        double m = hyperboleSliders[0].value;
        double k = hyperboleSliders[1].value;
        double km = 2*k*m;
        
        hyperboleEquationValues[0].text = (m*m).ToString("0.0000");           // m²
        if(km>=0){
            hyperboleEquationValues[1].text = "+" + km.ToString("0.0000");    // 2km 
        }else{
            hyperboleEquationValues[1].text = km.ToString("0.0000");          // 2km 
        }
        hyperboleEquationValues[2].text = (k*k).ToString("0.0000");           // k²

        Quaternion rotation = Quaternion.Euler(new Vector3(0,0, (float)m * 180));
        planes[state].GetComponent<Transform>().localRotation = rotation;
        planes[state].GetComponent<Transform>().localPosition = new Vector3((float)k, 0, 0);
    }

}