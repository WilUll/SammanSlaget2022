using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Slingshot : MonoBehaviour
{
    private GameObject grabbedObject;
    public Vector2 startMousePos, endMousePos;

    public float speed = 5f;
    private float Distance;
    private float Veloicty;

    public AudioClip[] AudioClips;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            endMousePos = new Vector2(
                Mathf.Clamp(Input.mousePosition.x, startMousePos.x - 400, startMousePos.x + 400),
                Mathf.Clamp(Input.mousePosition.y, startMousePos.y - 400, startMousePos.y - 200)
            );
            
            grabbedObject.GetComponent<Throwable>().DrawLine();
            grabbedObject.GetComponent<Trajectory>().DrawLine(endMousePos);
        }

        if (Input.GetMouseButtonUp(0)&& grabbedObject != null)
        {
            audioSource.clip = AudioClips[Random.Range(0, 2)];
            audioSource.Play();
            grabbedObject.GetComponent<Throwable>().Throw((endMousePos - startMousePos) * speed);
        }
    }
}
