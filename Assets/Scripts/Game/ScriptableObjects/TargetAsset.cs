using UnityEngine;

[CreateAssetMenu(fileName = "Target Asset", menuName = "Game/Target Asset")]
public class TargetAsset : ScriptableObject, IStorageAsset
{
    [SerializeField] private string _id;
    [SerializeField] private TargetBehaviour _prefab;
    [SerializeField] private AudioClip[] _hitSounds;
    [SerializeField] private AudioClip _explosionSound;

    public string Id => _id;
    public TargetBehaviour Prefab => _prefab;
    public AudioClip[] HitSounds => _hitSounds;
    public AudioClip ExplosionSound => _explosionSound;
}
