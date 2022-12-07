using UnityEngine;

[CreateAssetMenu(fileName = "Storage", menuName = "Game/Storage")]
public class Storage : ScriptableObject
{
    [SerializeField] private StorageAssets<TargetAsset> _targetStorage;
    [SerializeField] private StorageAssets<LevelAsset> _levelStorage;
    [SerializeField] private StorageAssets<WeaponAsset> _weaponStorage;

    public StorageAssets<TargetAsset> TargetStorage => _targetStorage;
    public StorageAssets<LevelAsset> LevelStorage => _levelStorage;
    public StorageAssets<WeaponAsset> WeaponStorage => _weaponStorage;
}
