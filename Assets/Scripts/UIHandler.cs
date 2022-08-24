using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public delegate void UpdateUI();

    public static UpdateUI myUpdateUI;
    public TextMeshProUGUI correctText;
    public TextMeshProUGUI missesText;

    private void Start()
    {
        myUpdateUI += UpdateText;

        myUpdateUI();
    }

    public void UpdateText()
    {
        correctText.text = $"Antal rätt: {GameManager.Correct}";
        missesText.text = $"Antal fel: {GameManager.Misses}";

    }
}
