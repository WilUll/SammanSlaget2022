using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float Speed;

    public Vector3 Rotation;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Rotation * Speed * Time.deltaTime);
    }
}
