using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Music : MonoBehaviour
{
    private new AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Mute()
    {
        audio.mute = !audio.mute;
    }
}
