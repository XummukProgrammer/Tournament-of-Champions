using UnityEngine;

[System.Serializable]
public class StorageAssets<T> where T : IStorageAsset
{
    [SerializeField] private T[] _assets;

    public T GetAsset(string id)
    {
        foreach (var asset in _assets)
        {
            if (asset.Id == id)
            {
                return asset;
            }
        }
        return default;
    }
}
