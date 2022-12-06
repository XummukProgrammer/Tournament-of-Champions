using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetBuilder
{
    [SerializeField] private Storage _storage;
    [SerializeField] Transform _container;
    [SerializeField] TargetBuilderElement[] _elements;

    List<Target> _controllers = new List<Target>();

    public List<Target> Controllers => _controllers;

    public void Create()
    {
        foreach (var element in _elements)
        {
            var asset = _storage.TargetStorage.GetAsset(element.Id);
            if (asset != null)
            {
                var controller = new Target();
                controller.Init(_container, asset.Prefab, element.Position, asset.HitSounds);
                _controllers.Add(controller);
            }
        }
    }

    public void DestroyController(Target controller)
    {
        _controllers.Remove(controller);
    }
}
