using System;
using System.Collections.Generic;

public class HUDManager
{
    private EntryPoint _entryPoint;
    private HUDContainerBehaviour _containerBehaviour;
    private List<HUD> _controllers = new List<HUD>();

    public void Init(EntryPoint entryPoint, HUDContainerBehaviour containerBehaviour)
    {
        _entryPoint = entryPoint;
        _containerBehaviour = containerBehaviour;
    }

    public void Deinit()
    {
        foreach (var controller in _controllers)
        {
            controller.Deinit();
        }

        _controllers.Clear();
    }

    public void Update()
    {
        foreach (var controller in _controllers)
        {
            controller.Update();
        }
    }

    public T CreateAndAddController<T>(HUDBehaviour prefab, HUDLocation location) where T : HUD
    {
        var controller = Activator.CreateInstance<T>();
        controller.InitWithParams(_entryPoint, prefab, location, _containerBehaviour);
        AddController(controller);
        return controller;
    }

    private void AddController(HUD controller)
    {
        controller.Init();
        _controllers.Add(controller);
    }
}
