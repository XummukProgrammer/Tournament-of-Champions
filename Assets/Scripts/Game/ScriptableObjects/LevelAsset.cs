using UnityEngine;

[CreateAssetMenu(fileName = "Level Asset", menuName = "Game/Level Asset")]
public class LevelAsset : ScriptableObject, IStorageAsset
{
    [SerializeField] private string _id;
    [SerializeField] private LevelElement[] _elements;

    public string Id => _id;
    public LevelElement[] Elements => _elements;
}
