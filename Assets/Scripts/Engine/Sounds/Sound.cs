using UnityEngine;

public class Sound
{
    private string _id;
    private AudioClip _audioClip;
    private Transform _container;
    private AudioSource _audioSource;

    public string Id => _id;

    public void Init(string id, Transform container, AudioSource baseAudioSource, AudioClip audioClip)
    {
        _id = id;

        _container = container;
        _audioClip = audioClip;

        _audioSource = GameObject.Instantiate(baseAudioSource, _container);
        _audioSource.clip = _audioClip;
        _audioSource.name = id;
    }

    public void Deinit()
    {
    }

    public void Play()
    {
        _audioSource.Play();
    }

    public void Stop()
    {
        _audioSource.Stop();
    }
}
