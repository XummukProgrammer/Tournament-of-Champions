using UnityEngine;

public class LevelWaveTargetElementBehaviour : LevelWaveElementBehaviour
{
    [SerializeField] private TargetAsset _asset;

    public override IController CreateController()
    {
        Target controller = new Target();
        controller.InitWithParams(_asset.Id, _asset.Prefab, transform.position,
            _asset.HealthValue, _asset.ZoneScores);
        return controller;
    }
}
