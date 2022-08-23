using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float ConveyorSpeed = 100f;
    public Vector3 Direction;
    private List<GameObject> onBelt;
    // Start is called before the first frame update
    void Start()
    {
        onBelt = new List<GameObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(Direction * Time.deltaTime * ConveyorSpeed, ForceMode.Acceleration);
    }
}
