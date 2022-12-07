using UnityEngine;

[CreateAssetMenu(fileName = "Game Asset", menuName = "Game/Game Asset")]
public class GameAsset : ScriptableObject
{
    [SerializeField] private string[] _levelsChain;

    public string[] LevelsChain => _levelsChain;
}
