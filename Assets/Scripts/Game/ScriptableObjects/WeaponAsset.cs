using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Asset", menuName = "Game/Weapon Asset")]
public class WeaponAsset : ScriptableObject, IStorageAsset
{
    [SerializeField] private string _id;
    [SerializeField] private int _damage;
    [SerializeField] private int _ammo;
    [SerializeField] private float _reloadDelay;
    [SerializeField] private Vector2[] _accuracyOffsets;
    [SerializeField] private float _accuracyChangeDelay;

    public string Id => _id;
    public int Damage => _damage;
    public int Ammo => _ammo;
    public float ReloadDelay => _reloadDelay;
    public Vector2[] AccuracyOffsets => _accuracyOffsets;
    public float AccuracyChangeDelay => _accuracyChangeDelay;
}
