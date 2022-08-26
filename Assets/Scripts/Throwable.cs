using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    private Rigidbody rb;
    public bool Grabbed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void DrawLine()
    {
        rb.isKinematic = true;
        Grabbed = true;
    }

    public void Throw(Vector3 force) {
        rb.isKinematic = false;
        rb.AddForce(new Vector3(force.y, 1, -force.x));
    }
}
