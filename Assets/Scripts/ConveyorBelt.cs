using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float ConveyorSpeed = 100f;
    public Vector3 Direction;
    public List<GameObject> onBelt;
    // Start is called before the first frame update
    void Start()
    {
        onBelt = new List<GameObject>();
    }

    public void GamePause(bool isPaused)
    {
        List<GameObject> gameObjectsToRemove = new List<GameObject>();
        foreach (var onBeltObject in onBelt)
        {
            if (onBeltObject != null)
            {
                onBeltObject.GetComponent<Rigidbody>().isKinematic = isPaused;
            }
            else
            {
                gameObjectsToRemove.Add(onBeltObject);
            }
        }
        
        foreach (GameObject o in gameObjectsToRemove)
        {
            onBelt.Remove(o);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<MovingObject>())
        {
            onBelt.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<MovingObject>())
        {
            onBelt.Remove(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<Throwable>().Grabbed)
        {
            other.GetComponent<Rigidbody>().AddForce(Direction * Time.deltaTime * ConveyorSpeed, ForceMode.Acceleration);
        }
    }
}
