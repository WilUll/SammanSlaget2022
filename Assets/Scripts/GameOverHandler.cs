using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public GameObject Earth;
    private Material earthMaterial;

    private Color materialColor;
    // Start is called before the first frame update
    void Start()
    {
        earthMaterial = Earth.GetComponent<MeshRenderer>().sharedMaterial;
        materialColor = new Color(0.5f - (GameManager.MoneyCollected/200), 0.5f - (GameManager.MoneyCollected/200), 0.5f - (GameManager.MoneyCollected/200),1f );

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
