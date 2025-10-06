using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioConfig : ScriptableObject
{
    public List<SoundClass> sounds;

    public SoundClass GetSoundClassByType(SoundType type)
    {
        foreach (var soundClass in sounds)
            if (type == soundClass.type && soundClass.sound != null)
                return soundClass;
        throw new Exception($"Can't return SoundClass by type {type}");
    }
}

[Serializable]
public class SoundClass
{
    public SoundType type;
    public AudioClip sound;
    [Range(0f, 1f)]
    public float volume = 0.5f;
}

public enum SoundType
{
    ClickButton, Lose, Shop, Upgrade, BurnCard, DrawCard
}