using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public Sprite onSprite;

    public Sprite offSprite;

    private Image buttonImage;

    private bool isOn = true;

    public AudioMixer audioMixer;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        ChangeSprite();
    }

    public void ChangeSprite()
    {

        buttonImage.sprite = isOn ? onSprite : offSprite;
        
        isOn = !isOn;


        if (isOn)
        {
            audioMixer.SetFloat("Music", -80f);
        }
        else
        {
            audioMixer.SetFloat("Music", 0f);
        }
    }
}
