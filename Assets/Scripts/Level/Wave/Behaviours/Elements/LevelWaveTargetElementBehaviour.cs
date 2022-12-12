using UnityEngine;

public class LevelWaveTargetElementBehaviour : LevelWaveElementBehaviour
{
    [SerializeField] private TargetAsset _asset;

    public override IController CreateController(Transform container)
    {
        Target controller = new Target();
        controller.InitWithParams(container, _asset.Prefab, transform.position, 
            _asset.HitSounds, _asset.ExplosionSound, 
            _asset.HitParticle, _asset.HealthValue, _asset.ZoneScores);
        return controller;
    }
}
