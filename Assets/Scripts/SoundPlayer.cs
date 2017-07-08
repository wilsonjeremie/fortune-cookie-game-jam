using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    public bool Music;
    AudioSource audio;

    void OnEnable()
    {
        if (Music)
        {
            SoundController.MusicUpdated += UpdateVolume;
        }
        else
        {
            SoundController.SoundUpdated += UpdateVolume;
        }
    }

    void OnDisable()
    {
        if (Music)
        {
            SoundController.MusicUpdated -= UpdateVolume;
        }
        else
        {
            SoundController.SoundUpdated -= UpdateVolume;
        }
    }

	void Start () {
        audio = GetComponent<AudioSource>();

        if (Music)
            UpdateVolume(SoundController.MusicVolume);
        else
            UpdateVolume(SoundController.SoundVolume);
	}

    void UpdateVolume(float value)
    {
        audio.volume = value;
    }
}
