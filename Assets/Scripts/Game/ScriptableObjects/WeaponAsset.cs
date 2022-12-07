using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Asset", menuName = "Game/Weapon Asset")]
public class WeaponAsset : ScriptableObject, IStorageAsset
{
    [SerializeField] private string _id;
    [SerializeField] private int _damage;

    public string Id => _id;
    public int Damage => _damage;
}
