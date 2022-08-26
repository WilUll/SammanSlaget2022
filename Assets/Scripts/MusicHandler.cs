using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    private AudioSource _audioSource;
    public bool AudioIsMuted = false;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    public void MuteAudio()
    {
        AudioIsMuted = !AudioIsMuted;
    }
}
