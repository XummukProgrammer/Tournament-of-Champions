using UnityEngine;

[System.Serializable]
public class TargetZoneScore
{
    [SerializeField] private string _id;
    [SerializeField] private int _score;

    public string Id => _id;
    public int Score => _score;
}
