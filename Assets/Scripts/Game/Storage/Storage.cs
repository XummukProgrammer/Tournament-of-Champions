using UnityEngine;

[CreateAssetMenu(fileName = "Storage", menuName = "Game/Storage")]
public class Storage : ScriptableObject
{
    [SerializeField] private StorageAssets<TargetAsset> _targetStorage;

    public StorageAssets<TargetAsset> TargetStorage => _targetStorage;
}
