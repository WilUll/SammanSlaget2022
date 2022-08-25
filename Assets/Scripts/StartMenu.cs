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

    private void Start()
    {
        GameButton.color = new Color(DisplayText.color.r, DisplayText.color.g, DisplayText.color.b, 0);
        StartCoroutine(FadeInText(DisplayText, 2f, true));
    }

    IEnumerator FadeInText(TextMeshProUGUI textToFade, float time, bool fadeOut)
    {
        textToFade.color = new Color(DisplayText.color.r, DisplayText.color.g, DisplayText.color.b, 0);
        while (DisplayText.color.a < 1.0f)
        {
            textToFade.color = new Color(DisplayText.color.r, DisplayText.color.g, DisplayText.color.b, DisplayText.color.a + (Time.deltaTime / time));
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
        textToFade.color = new Color(DisplayText.color.r, DisplayText.color.g, DisplayText.color.b, 1);
        while (DisplayText.color.a > 0.0f)
        {
            textToFade.color = new Color(DisplayText.color.r, DisplayText.color.g, DisplayText.color.b, DisplayText.color.a - (Time.deltaTime / time));
            yield return null;
        }

        StartCoroutine(FadeInText(GameButton, 1, false));
    }
}
