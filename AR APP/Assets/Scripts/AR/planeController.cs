using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class planeController : MonoBehaviour
{
    public Button[] buttons;
    public Slider[] sliders;
    //public TextMesh sliderZValue;
    public Transform[] planesTransform;
    public GameObject[] planes;
    public Transform plane;

    void Start()   
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int closureIndex = i; // Prevents the closure problem
            buttons[closureIndex].onClick.AddListener(() => TaskOnClick(closureIndex));
        }
    }
    // Update is called once per frame
    void Update()
    {
        //planesTransform[1].localPosition = new Vector3(sliders[0].value, sliders[0].value*2, 0);
        //planesTransform[1].localPosition = new Vector3(sliders[0].value, sliders[0].value*3, 0);
        
        planesTransform[1].localPosition = new Vector3(-sliders[0].value/2, sliders[0].value, 0);
    }
    public void TaskOnClick(int buttonIndex)
    {   
        //x=z,y=x,z=y
        //Debug.Log("You have clicked the button #" + buttonIndex, buttons[buttonIndex]);
        foreach (GameObject plane in planes)
        {
            plane.active = false;
            
        }
        if (buttonIndex == 0)
        {
            CircunferencekClick();
            
        }
        else if (buttonIndex == 1)
        {
         
        }
        else if (buttonIndex == 2)
        {
            
        }
        else
        {

        }
        
    }
    public void CircunferencekClick() {
        
    }
}
