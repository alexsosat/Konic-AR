using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*El siguiente script tiene el proposito de crear una linea que se renderize constantemente para seguir al punto que se mueve alrededor de la elpse*/
public class MovLinea : MonoBehaviour
{
    LineRenderer lineRenderer;
    
    public Transform origin;
    public Transform destination;
    

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetWidth(.05f, .05f);
        Vector3 pointA = origin.position;
        Vector3 pointB = destination.position;
        
        
    }

    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
    }
}
