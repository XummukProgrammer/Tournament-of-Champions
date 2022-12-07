using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetBuilder
{
    [SerializeField] private Storage _storage;
    [SerializeField] Transform _container;
    [SerializeField] string _levelId;

    List<Target> _controllers = new List<Target>();

    public List<Target> Controllers => _controllers;

    public void Create()
    {
        var levelStorage = _storage.LevelStorage.GetAsset(_levelId);
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
                controller.Init(_container, asset.Prefab, element.Position, asset.HitSounds, asset.ExplosionSound, asset.HitParticle);
                _controllers.Add(controller);
            }
        }
    }

    public void DestroyController(Target controller)
    {
        _controllers.Remove(controller);
    }
}
