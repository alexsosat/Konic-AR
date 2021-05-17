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
    public Text planeText;
    public Button[] buttons;
    public Slider[] sliders;
    public TextMeshPro[] sliderZValue;
    //public Slider z;
    public GameObject[] initial_planes;
    public GameObject[] ellipse_planes;
    // public GameObject[] parabola_planes;
    // public GameObject[] hiperbola_planes;
    public GameObject[] UI;
    public GameObject[] texts;
    public Toggle[] ellipseOptions;

    private int state = 0;
    public SpriteRenderer ellipseFormulaImage;
    public Sprite[] ellipseFormulaOptions;

    public Toggle animEllipse;
    public GameObject conic, ellipse;
    public Image img;




    void Start()
    {
        
        img.gameObject.SetActive(false);
        TextMeshPro t = (TextMeshPro)gameObject.GetComponent(typeof(TextMeshPro));
        
        for (int i = 0; i < buttons.Length; i++)
        {
            // Debug.Log(buttons[i]);
            int closureIndex = i; // Prevents the closure problem
            buttons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }
        //buttons[2].interactable = false;
        //buttons[3].interactable = false;
        //animEllipse = GetComponent<Toggle>();
        //Add listener for when the state of the Toggle changes, to take action
        animEllipse.onValueChanged.AddListener(delegate  { ToggleValueChanged(animEllipse);  });
        animEllipse.interactable = false;
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
    void ToggleValueChanged(Toggle change){
            if (change.isOn == true){                
                UI[1].SetActive(false);
                UI[2].SetActive(false);
                UI[3].SetActive(false);
                for (int i = 0; i < buttons.Length; i++){
                    buttons[i].interactable = false;
                }
                 ellipse.SetActive(true);
                 img.gameObject.SetActive(true);
                 conic.SetActive(false);
            }
            else if (change.isOn == false){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
    }

    public void TaskOnClick(int buttonIndex){
        Debug.Log(buttonIndex);
        foreach (GameObject plane in initial_planes){
            plane.active = false;
        }
        foreach (GameObject plane in ellipse_planes){
            plane.active = false;
        }
        // foreach(GameObject plane in parabola_planes){
        //     plane.active = false;
        // }
        // foreach(GameObject plane in hiperbola_planes){
        //     plane.active = false;
        // }

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
            initial_planes[0].SetActive(true);
            UI[0].SetActive(true);
            texts[0].SetActive(true);
        }
        else if (buttonIndex == 1)
        {
            planeText.text = "ELIPSE";
            state = 1;
            initial_planes[1].SetActive(true);
            UI[1].SetActive(true);
            texts[1].SetActive(true);
        }
        else if (buttonIndex == 2)
        {
            planeText.text = "PARÁBOLA";
            state = 2;
            initial_planes[2].SetActive(true);
            UI[2].SetActive(true);
            texts[2].SetActive(true);
        }
        else if (buttonIndex == 3)
        {
            planeText.text = "HIPÉRBOLA";
            state = 3;
            initial_planes[3].SetActive(true);
            UI[3].SetActive(true);
            texts[3].SetActive(true);
        }
        Debug.Log("You have clicked the button #" + buttonIndex, buttons[buttonIndex]);
    }


    public void Circunferencia()
    {
        sliderZValue[0].text = Math.Pow(sliders[0].value * 5, 2).ToString("0.0");
        initial_planes[state].GetComponent<Transform>().localPosition = new Vector3(0, sliders[0].value, 0);

    }
    public void Ellipse()
    {
        //animEllipse.interactable = true;//if (ellipseOptions[0].isOn)//{//ellipseFormulaImage.sprite = ellipseFormulaOptions[0];//sliders[1].maxValue = 0.5637287f;
        
        //(1 − 𝑚²)𝑥² + 2𝑘𝑚𝑥 + 𝑦² − 𝑘² = 0
        double k = sliders[1].value;
        double m = sliders[2].value;
        double km = 2*k*m;

       
        sliderZValue[1].text = (k*k).ToString("0.0000");            // k²
        sliderZValue[2].text = (1-m*m).ToString("0.0000");          // m²
        if(km<0){
            sliderZValue[11].text = km.ToString("0.0000");          // 2km 
        }else{
            sliderZValue[11].text = "+" + km.ToString("0.0000");    // 2km 
        }
        double val = Math.Round(sliders[2].value * 20) / 20;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, (float)val * 45));
        initial_planes[state].GetComponent<Transform>().localRotation = rotation;
        ellipse_planes[0].GetComponent<Transform>().localPosition = new Vector3(0, sliders[1].value, 0);
            
        //}//else if (ellipseOptions[1].isOn)//{//    animEllipse.interactable = true;//    ellipseFormulaImage.sprite = ellipseFormulaOptions[1];//    sliders[1].maxValue = 0.6943489f;//    ellipse_planes[1].GetComponent<Transform>().localPosition = new Vector3(sliders[1].value / 3, sliders[1].value, 0);//    sliderZValue[1].text = System.Math.Pow(sliders[1].value * 5, 2).ToString("0.0");//    sliderZValue[2].text = (sliders[1].value * 5 * 2).ToString("0.0");//}
        //else if (ellipseOptions[2].isOn)//{//    ellipseFormulaImage.sprite = ellipseFormulaOptions[2];//    sliders[1].maxValue = 0.3156974f;//    ellipse_planes[2].GetComponent<Transform>().localPosition = new Vector3(sliders[1].value * 1.5f, sliders[1].value, 0);//    sliderZValue[1].text = System.Math.Pow(sliders[1].value * 5, 2).ToString("0.0");//    sliderZValue[2].text = (sliders[1].value * 5 * 8).ToString("0.0");//}
    }

    public void Parabola (){
        //y² = -2k ( x - k/2)
        double k = sliders[3].value;

        //sliderZValue[9].text = new Fraction(Math.Round(-2*k, 4));//.ToString("0.0");      //-2k
        //sliderZValue[5].text = new Fraction(Math.Round(k / 2,4));//.ToString("0.00");       //k/2

        sliderZValue[9].text = (-2*k).ToString("0.0000");               //-2k 
        if((k/2)>=0){            
            Debug.Log(k/2);
            sliderZValue[5].text = "+" + (k / 2).ToString("0.0000");    //k/2
        }else{
            sliderZValue[5].text = (k / 2).ToString("0.0000");          //k/2
        }
        initial_planes[state].GetComponent<Transform>().localPosition = new Vector3(0, (float).5, (float)(k-.5));
    }

    public void Hiperbola(){
        //(1 - m²)x² + 2kmx + y² - k² = 0
        double m = sliders[4].value;
        double k = sliders[5].value;
        double km = 2*k*m;
        
        sliderZValue[6].text = (m*m).ToString("0.0000");           // m²
        if(km>=0){
            sliderZValue[7].text = "+" + km.ToString("0.0000");    // 2km 
        }else{
            sliderZValue[7].text = km.ToString("0.0000");          // 2km 
        }
        sliderZValue[8].text = (k*k).ToString("0.0000");           // k²

        Quaternion rotation = Quaternion.Euler(new Vector3(0,0, (float)m * 180));
        initial_planes[state].GetComponent<Transform>().localRotation = rotation;
        initial_planes[state].GetComponent<Transform>().localPosition = new Vector3((float)k, 0, 0);
    }

}