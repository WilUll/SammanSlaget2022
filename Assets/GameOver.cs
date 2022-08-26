using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;

    public TextMeshProUGUI GameButton;

    public string[] texts;
    private int textInt;
    
    private void Start()
    {
        DisplayText.color = new Color(DisplayText.color.r, DisplayText.color.g, DisplayText.color.b, 0);
        GameButton.color = new Color(GameButton.color.r, GameButton.color.g, GameButton.color.b, 0);
        DisplayText.text = texts[textInt];
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
            yield return new WaitForSeconds(2.5f);

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

        textInt++;
        if (textInt <= 2)
        {
            textToFade.text = texts[textInt];
            StartCoroutine(FadeInText(textToFade, 1, true));
        }
        else
        {
            textToFade.text = $"Du samlade in {GameManager.MoneyCollected} kr!";
            StartCoroutine(FadeInText(textToFade, 1, false));
            StartCoroutine(FadeInText(GameButton, 1, false));

        }
    }
}
