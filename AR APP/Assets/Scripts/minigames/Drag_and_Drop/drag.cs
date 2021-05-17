using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    bool startDrag = false;
    public GameObject draggable;

    private void Update()
    {
        if (startDrag)
        {
            draggable.transform.position = Input.mousePosition;
        }
    }

    public void enableDragUI(bool state)
    {
        startDrag = state;
    }


}
