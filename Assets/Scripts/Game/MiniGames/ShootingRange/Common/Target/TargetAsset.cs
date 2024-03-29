using UnityEngine;

[CreateAssetMenu(fileName = "Target Asset", menuName = "Game/Target Asset")]
public class TargetAsset : ScriptableObject, IStorageAsset
{
    [SerializeField] private string _id;
    [SerializeField] private TargetBehaviour _prefab;
    [SerializeField] private int _healthValue;
    [SerializeField] private TargetZoneScore[] _zoneScores;

    public string Id => _id;
    public TargetBehaviour Prefab => _prefab;
    public int HealthValue => _healthValue;
    public TargetZoneScore[] ZoneScores => _zoneScores;
}
