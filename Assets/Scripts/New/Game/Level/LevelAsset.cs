using UnityEngine;

[CreateAssetMenu(fileName = "Level Asset", menuName = "Game/Level Asset")]
public class LevelAsset : ScriptableObject
{
    [SerializeField] private LevelWaveBehaviour[] _waveBehaviours;

    public LevelWaveBehaviour[] WaveBehaviours => _waveBehaviours;
}
