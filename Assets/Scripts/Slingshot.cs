using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    private GameObject grabbedObject;
    public Vector2 startMousePos, endMousePos;

    public float speed = 5f;
    private float Distance;
    private float Veloicty;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform.gameObject.GetComponent<Throwable>())
                {
                    grabbedObject = hit.transform.gameObject;
                }
            }
        }

        if (Input.GetMouseButton(0) && grabbedObject != null)
        {
            endMousePos = Input.mousePosition;
            grabbedObject.GetComponent<Throwable>().DrawLine();
        }

        if (Input.GetMouseButtonUp(0)&& grabbedObject != null)
        {
            grabbedObject.GetComponent<Throwable>().Throw((endMousePos - startMousePos) * speed);
        }
    }
}
