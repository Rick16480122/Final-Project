using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class AnimalSounds : MonoBehaviour
{
    public List<AudioClip> sounds;
    public float minTime = 5f, maxTime = 20f;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (sounds.Count > 0)
            StartCoroutine(SoundTimer());
    }

    IEnumerator SoundTimer()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        _audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
        StartCoroutine(SoundTimer());
    }
}
