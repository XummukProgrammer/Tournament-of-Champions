using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShootingRangeTargetSoundInfo
{
    [SerializeField] private string _id;
    [SerializeField] private string[] _soundIds;

    public string Id => _id;
    public string[] SoundIds => _soundIds;
}
