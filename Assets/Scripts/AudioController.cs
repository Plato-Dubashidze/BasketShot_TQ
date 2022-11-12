using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioClip rim, bounce, net, shoot, star;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        GlobalEventManager.starCollected.AddListener(Star);
        GlobalEventManager.shoot.AddListener(Shoot);
        GlobalEventManager.netReached.AddListener(Net);
        GlobalEventManager.bounce.AddListener(Bounce);
        GlobalEventManager.rimTouch.AddListener(Rim);
    }

    private void Rim()
    {
        audioSource.clip = rim;
        audioSource.Play();
    }

    private void Bounce()
    {
        audioSource.clip = bounce;
        audioSource.Play();
    }

    private void Net()
    {
        audioSource.clip = net;
        audioSource.Play();
    }

    private void Shoot(Vector3 arg0)
    {
        audioSource.clip = shoot;
        audioSource.Play();
    }

    private void Star()
    {
        audioSource.clip = star;
        audioSource.Play();
    }
}
