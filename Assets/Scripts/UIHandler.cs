using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public delegate void UpdateUI();

    public static UpdateUI myUpdateUI;
    public TextMeshProUGUI MoneyText;

    public GameObject Earth;
    private Material earthMaterial;

    private Color materialColor;


    private void Start()
    {
        earthMaterial = Earth.GetComponent<MeshRenderer>().sharedMaterial;
        materialColor = new Color(0.5f - (GameManager.MoneyCollected/200), 0.5f - (GameManager.MoneyCollected/200), 0.5f - (GameManager.MoneyCollected/200),1f );



        myUpdateUI += UpdateText;

        myUpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameManager.MoneyCollected += 10;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameManager.MoneyCollected -= 10;
        }

        UpdateText();
    }

    private void SetColors()
    {
        earthMaterial.color = materialColor;
        Earth.GetComponent<MeshRenderer>().sharedMaterial = earthMaterial;
    }

    public void UpdateText()
    {
        MoneyText.text = $"Insamlade pengar: {GameManager.MoneyCollected} kr";

        materialColor = new Color(0.5f + (GameManager.MoneyCollected/200f), 0.5f + (GameManager.MoneyCollected/200f), 0.5f + (GameManager.MoneyCollected/200f),1f );
        SetColors();
        
        if (GameManager.MoneyCollected <= -100 || GameManager.MoneyCollected >= 100)
        {
            if (GetComponent<LoadNextScene>())
            {
                GetComponent<LoadNextScene>().GameOver();
            }
        }
    }
}
