using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Music : MonoBehaviour
{
    private new AudioSource audio;

    [SerializeField] private AudioSource soundButton;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Mute()
    {
        soundButton.Play();
        audio.mute = !audio.mute;
    }
}
