using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_audio : MonoBehaviour
{
    public AudioSource dooropen;
    public void AudioPlay()
    {
        dooropen.Play();
    }

}
