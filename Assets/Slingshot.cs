using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public bool leftClickDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            leftClickDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            leftClickDown = false;
        }
    }
}
