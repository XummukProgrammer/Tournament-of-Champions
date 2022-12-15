using UnityEngine;

public class ShootingRangeLevelComponent : GameComponent
{
    [SerializeField] private LevelAsset _asset;

    public LevelAsset Asset => _asset;
}
