using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioClip rim, bounce, net, shoot, star;

    private AudioSource audioSourceRim, audioSourceStar, audioSourceShoot, audioSourceNet, audioSourceBounce;

    private void Awake()
    {

        AddListeners();
        SetupSources();

    }

    private void Rim()
    {

        audioSourceRim.Play();
    }

    private void Bounce()
    {

        audioSourceBounce.Play();
    }

    private void Net()
    {

        audioSourceNet.Play();
    }

    private void Shoot(Vector3 arg0)
    {

        audioSourceShoot.Play();
    }

    private void Star()
    {

        audioSourceStar.Play();
    }

    private void AddListeners()
    {
        GlobalEventManager.starCollected.AddListener(Star);
        GlobalEventManager.shoot.AddListener(Shoot);
        GlobalEventManager.netReached.AddListener(Net);
        GlobalEventManager.bounce.AddListener(Bounce);
        GlobalEventManager.rimTouch.AddListener(Rim);
    }

    private void SetupSources()
    {
        audioSourceRim = gameObject.AddComponent<AudioSource>();
        audioSourceRim.playOnAwake = false;
        audioSourceRim.clip = rim;
        audioSourceRim.volume = 0.3f;

        audioSourceNet = gameObject.AddComponent<AudioSource>();
        audioSourceNet.playOnAwake = false;
        audioSourceNet.clip = net;
        audioSourceNet.volume = 0.8f;

        audioSourceShoot = gameObject.AddComponent<AudioSource>();
        audioSourceShoot.playOnAwake = false;
        audioSourceShoot.clip = shoot;
        audioSourceShoot.volume = 0.6f;

        audioSourceBounce = gameObject.AddComponent<AudioSource>();
        audioSourceBounce.playOnAwake = false;
        audioSourceBounce.clip = bounce;
        audioSourceBounce.volume = 1f;

        audioSourceStar = gameObject.AddComponent<AudioSource>();
        audioSourceStar.playOnAwake = false;
        audioSourceStar.clip = star;
        audioSourceStar.volume = 1f;
    }
}
