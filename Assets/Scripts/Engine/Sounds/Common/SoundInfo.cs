using UnityEngine;

[System.Serializable]
public class SoundInfo
{
    [SerializeField] private string _id;
    [SerializeField] private AudioClip _audioClip;

    public string Id => _id;
    public AudioClip AudioClip => _audioClip;
}
