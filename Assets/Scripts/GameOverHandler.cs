using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    public GameObject Earth;
    private Material earthMaterial;
    public TextMeshProUGUI MoneyCollectedText;
    public Button button;


    private Color materialColor;
    // Start is called before the first frame update
    void Start()
    {
        earthMaterial = Earth.GetComponent<MeshRenderer>().sharedMaterial;
        materialColor = new Color(0.5f - (GameManager.MoneyCollected/200), 0.5f - (GameManager.MoneyCollected/200), 0.5f - (GameManager.MoneyCollected/200),1f );
        MoneyCollectedText.text = $"Du samlade in {GameManager.MoneyCollected}!";
        if (GameManager.MoneyCollected < 0)
        {
            MoneyCollectedText.color = new Color(1, 1, 1, 1);
            ColorBlock cb = button.colors;
            cb.normalColor = new Color(1, 1, 1, 1);
            button.colors = cb;
        }
        else
        {
            MoneyCollectedText.color = new Color(0, 0, 0, 1);
            ColorBlock cb = button.colors;
            cb.normalColor = new Color(0, 0, 0, 1);
            button.colors = cb;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
