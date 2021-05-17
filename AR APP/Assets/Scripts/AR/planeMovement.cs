using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class planeMovement : MonoBehaviour
{
    public TextMesh sliderZValue;
    public Slider z;
    public Transform plane;
     
    private void Start()
    {
        TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));

    }

    void Update()
    {
        sliderZValue.text = "X^2 + Y^2 = " + System.Math.Pow((z.value*5),2).ToString("0.0");
        plane.localPosition = new Vector3(0,z.value,0);
    }
}
