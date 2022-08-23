using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Throw(Vector3 force) {
        rb.isKinematic = false;
        rb.AddForce(rb.mass * force, ForceMode.Impulse);
    }
}
