using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseLine : MonoBehaviour
{
    private LineRenderer lineRederer;
    [Range(3,36)]
    public int segments;
    public EllipseOrbit ellipse;
    //public float xAxis=5f;
    //public float yAxis=3f;

    // Start is called before the first frame update
    void Start()
    {
        lineRederer = GetComponent<LineRenderer>();
        CalculateEllips();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CalculateEllips() {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++) {
            Vector2 position2D = ellipse.Evaluate((float)i / (float)segments);
            points[i] = new Vector3(position2D.x, 0f, position2D.y);
        }
        points[segments] = points[0];
        lineRederer.positionCount = segments + 1;
        lineRederer.SetPositions(points);
    }
}
