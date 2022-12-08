using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetBuilder
{
    [SerializeField] private Storage _storage;
    [SerializeField] Transform _container;

    List<Target> _controllers = new List<Target>();

    public List<Target> Controllers => _controllers;

    public void Load(string levelId)
    {
        var levelStorage = _storage.LevelStorage.GetAsset(levelId);
        if (levelStorage == null)
        {
            return;
        }

        foreach (var element in levelStorage.Elements)
        {
            var asset = _storage.TargetStorage.GetAsset(element.Id);
            if (asset != null)
            {
                var controller = new Target();
                controller.Init(_container, asset.Prefab, element.Position, asset.HitSounds, asset.ExplosionSound, asset.HitParticle, asset.HealthValue, asset.ZoneScores);
                _controllers.Add(controller);
            }
        }
    }

    public void DestroyController(Target controller)
    {
        _controllers.Remove(controller);
    }

    public void DestroyAllControllers()
    {
        foreach (var controller in _controllers)
        {
            GameObject.Destroy(controller.Behaviour.gameObject);
        }
        _controllers.Clear();
    }
}
