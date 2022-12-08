using UnityEngine;

[CreateAssetMenu(fileName = "Game Asset", menuName = "Game/Game Asset")]
public class GameAsset : ScriptableObject
{
    [SerializeField] private string[] _levelsChain;
    [SerializeField] private string _playerWeaponId;

    public string[] LevelsChain => _levelsChain;
    public string PlayerWeaponId => _playerWeaponId;
}
