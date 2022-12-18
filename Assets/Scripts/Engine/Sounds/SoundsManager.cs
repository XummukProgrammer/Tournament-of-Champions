using System.Collections.Generic;
using UnityEngine;

public class SoundsManager
{
    private AudioSource _baseAudioSource;
    private Transform _container;
    private List<Sound> _sounds = new List<Sound>();

    public void Init(Transform container, AudioSource baseAudioSound)
    {
        _container = container;
        _baseAudioSource = baseAudioSound;
    }

    public void Deinit()
    {
        foreach (var sound in _sounds)
        {
            sound.Deinit();
        }
    }

    public void Update()
    {
    }

    public void CreateSound(string id, AudioClip audioClip)
    {
        var sound = new Sound();
        sound.Init(id, _container, _baseAudioSource, audioClip);
        _sounds.Add(sound);
    }

    public Sound GetSound(string id)
    {
        foreach (var sound in _sounds)
        {
            if (sound.Id == id)
            {
                return sound;
            }
        }

        return null;
    }

    public void PlaySound(string id)
    {
        var sound = GetSound(id);
        if (sound != null)
        {
            sound.Play();
        }
    }

    public void StopSound(string id)
    {
        var sound = GetSound(id);
        if (sound != null)
        {
            sound.Stop();
        }
    }
}
