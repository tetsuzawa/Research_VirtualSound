﻿using UnityEngine;
using System.Collections;

public class SoundTest : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        audioSource.Play();
    }

}