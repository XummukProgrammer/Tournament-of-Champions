using System;
using System.Collections.Generic;

public class HUDManager
{
    Game _game;
    private HUDContainerBehaviour _containerBehaviour;
    private List<HUD> _controllers = new List<HUD>();

    public void Init(Game game, HUDContainerBehaviour containerBehaviour)
    {
        _game = game;
        _containerBehaviour = containerBehaviour;
    }

    public void Deinit()
    {
        foreach (var controller in _controllers)
        {
            controller.Deinit();
        }
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
        controller.InitWithParams(_game, prefab, location, _containerBehaviour);
        AddController(controller);
        return controller;
    }

    private void AddController(HUD controller)
    {
        controller.Init();
        _controllers.Add(controller);
    }
}
