using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundController {
    public static event Action<float> MusicUpdated;
    public static event Action<float> SoundUpdated;

    public static float MusicVolume
    {
        get { return musicVolume; }
        set
        {
            musicVolume = value;
            if (MusicUpdated != null) MusicUpdated(value);
        }
    }
    public static float SoundVolume
    {
        get { return musicVolume; }
        set
        {
            soundVolume = value;
            if (SoundUpdated != null) SoundUpdated(value);
        }
    }

    static SoundController()
    {
        musicVolume = 1f;
        soundVolume = 1f;
    }

    static float musicVolume;
    static float soundVolume;
}
