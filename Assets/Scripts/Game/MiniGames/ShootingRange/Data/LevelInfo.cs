using UnityEngine;

[System.Serializable]
public class LevelInfo
{
    [SerializeField] private float _entryAddTime = 10;

    public float EntryAddTime => _entryAddTime;
}
