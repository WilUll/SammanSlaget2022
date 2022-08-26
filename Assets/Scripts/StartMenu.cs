using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;

    public TextMeshProUGUI GameButton;

    private string textAfter = "Sortera, samla in 100 kr och rädda världen!";

    private void Start()
    {
        GameButton.color = new Color(GameButton.color.r, GameButton.color.g, GameButton.color.b, 0);
        StartCoroutine(FadeInText(DisplayText, 2f, true));
    }

    IEnumerator FadeInText(TextMeshProUGUI textToFade, float time, bool fadeOut)
    {
        textToFade.color = new Color(textToFade.color.r, textToFade.color.g, textToFade.color.b, 0);
        while (textToFade.color.a < 1.0f)
        {
            textToFade.color = new Color(textToFade.color.r, textToFade.color.g, textToFade.color.b, textToFade.color.a + (Time.deltaTime / time));
            yield return null;
        }

        if (fadeOut)
        {
            yield return new WaitForSeconds(5f);

            StartCoroutine(FadeOutText(textToFade, time));
        }
    }

    IEnumerator FadeOutText(TextMeshProUGUI textToFade, float time)
    {
        textToFade.color = new Color(textToFade.color.r, textToFade.color.g, textToFade.color.b, 1);
        while (textToFade.color.a > 0.0f)
        {
            textToFade.color = new Color(textToFade.color.r, textToFade.color.g, textToFade.color.b, textToFade.color.a - (Time.deltaTime / time));
            yield return null;
        }

        textToFade.text = textAfter;
        StartCoroutine(FadeInText(textToFade, 1, false));
        StartCoroutine(FadeInText(GameButton, 3f, false));
    }
}
