using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform bar;
    public bool increase;

    public float resizeAmount;



    public float speed = 45.0f;
    public Transform orbitingObject;
    public EllipseOrbit orbithPath;
    [Range(0f,1f)]
    public float orbitProgress=0f;
    public float orbitPeriod = 3f;
    public bool orbitActive = true;

    void Start() {
        increase = false;
        if (orbitingObject == null) {
            orbitActive = false;
            return;
        }
        SetOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    }
  

    void SetOrbitingObjectPosition() {
        Vector2 orbitPos = orbithPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x,0,orbitPos.y);
        
        
    }
    
    IEnumerator AnimateOrbit() {
        
        if (orbitPeriod < 0.1f) {
            orbitPeriod = 0.1f;
            
        }
        float orbitSpeed = 1f / orbitPeriod;
        
        while (orbitActive) {
            
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitingObjectPosition();
            Vector2 orbitPos = orbithPath.Evaluate(orbitProgress);
            if (bar.transform.localScale.x < 0.2 && orbitPos.y > 0)
            {
                increase=true;
            }
            if (bar.transform.localScale.x > 0.8 && orbitPos.y < 0)
            {
                increase = false;
            }
            if (increase == true )
            {
                bar.transform.localScale = new Vector3(bar.transform.localScale.x + resizeAmount, bar.transform.localScale.z, bar.transform.localScale.y);
            }
            else if (increase == false )
            {
                bar.transform.localScale = new Vector3(bar.transform.localScale.x - resizeAmount, bar.transform.localScale.z, bar.transform.localScale.y);
            }
            yield return null;
        }
    }
    /*
    //public Transform p, p2,s3;
    public float a;
    public float b;
    //public float c;
    public float alpha;
    public float deltaAlpha;
    public Vector3 center;
    //public Transform object_a;
    //public Transform object_b;
    //public float rotationSpeed = 2; //speed of turning
    void Start() { 
    }
    void Update() {
        //center = new Vector3(object_a.position.x + c, 0, object_a.position.z);
        //esfera gira
        //transform.position = new Vector3(center.y  * Mathf.Cos(alpha), center.z  * Mathf.Sin(alpha), 0);
        transform.position = new Vector3(center.x + a * Mathf.Cos(alpha), 0, center.z + b * Mathf.Sin(alpha));
        //c = Mathf.Sqrt(a * a - b * b);
        //p2.transform.Translate(0, center.x + a * Mathf.Cos(alpha), center.z + b * Mathf.Sin(alpha), Space.Self);
        //p2.transform.position = new Vector3(center.x + * Mathf.Cos(alpha), 0, center.z + b * Mathf.Sin(alpha));
        //p.transform.Rotate(new Vector3(0, -5, 0), Space.World);
        //p2.transform.Rotate(new Vector3(0, -5, 0), Space.World);
        alpha += deltaAlpha;
        //p.localScale = Vector2.one * growFactor;
        //p.transform.localScale += new Vector3(0, 1, 0) * Time.deltaTime * growFactor;
        //p2.transform.LookAt(s3.transform.position);
        //p2.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        // p2.transform.rotation = Quaternion.Slerp(p2.transform.rotation, Quaternion.LookRotation(transform.position - p2.transform.position, Vector3.up), rotationSpeed* Time.deltaTime);
        //ScaleAround(p, p, transform.position);

    }
    */
}
