using System;
using System.Collections.Generic;
using UnityEngine;

public enum EffectContainerType
{
    World,
    Canvas
}

public class EffectsManager
{
    public delegate void PreInitDelegate<T>(T effect);

    private EntryPoint _entryPoint;
    private Transform _worldContainer;
    private Transform _canvasContainer;
    private List<Effect> _effects = new List<Effect>();
    private List<Effect> _destroyEffects = new List<Effect>();

    public void Init(EntryPoint entryPoint, Transform worldContainer, Transform canvasContainer)
    {
        _entryPoint = entryPoint;
        _worldContainer = worldContainer;
        _canvasContainer = canvasContainer;
    }

    public void Deinit()
    {
        foreach (var effect in _effects)
        {
            effect.Deinit();
        }

        _effects.Clear();
    }

    public void Update()
    {
        foreach (var effect in _effects)
        {
            if (effect.IsDestroy())
            {
                _destroyEffects.Add(effect);
            }
        }

        foreach (var effect in _destroyEffects)
        {
            effect.Deinit();
            _effects.Remove(effect);
        }

        _destroyEffects.Clear();
    }

    public T CreateAndAddEffect<T>(PreInitDelegate<T> preInitDelegate, EffectContainerType containerType) where T : Effect
    {
        var effect = Activator.CreateInstance<T>();
        preInitDelegate?.Invoke(effect);
        effect.Init(_entryPoint, GetContainerByType(containerType));
        _effects.Add(effect);
        return effect;
    }

    private Transform GetContainerByType(EffectContainerType containerType)
    {
        switch (containerType)
        {
            case EffectContainerType.World:
                return _worldContainer;
            case EffectContainerType.Canvas:
                return _canvasContainer;
            default:
                break;
        }
        return null;
    }
}
