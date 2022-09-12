using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundEffect
{
    public float Volume = 0.5f;
    public float SpatialBlend = 0;
    public AudioClip[] clips;

    public AudioClip GetClip()
    {
        if (clips.Length <= 0)
            return null;

        AudioClip clip = clips[Random.Range(0, clips.Length)];

        return clip;
    }
}
