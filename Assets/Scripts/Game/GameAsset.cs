using UnityEngine;

[CreateAssetMenu(fileName = "Game Asset", menuName = "Game/Game Asset")]
public class GameAsset : ScriptableObject
{
    [SerializeField] private string _playerWeaponId;
    [SerializeField] private GameComponents _componentsPrefab;

    public string PlayerWeaponId => _playerWeaponId;
    public GameComponents ComponentsPrefab => _componentsPrefab;
}
