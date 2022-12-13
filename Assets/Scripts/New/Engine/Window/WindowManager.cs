using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager
{
    private Game _game;
    private Transform _container;
    private List<Window> _controllers = new List<Window>();

    public void Init(Game game, Transform container)
    {
        _game = game;
        _container = container;
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

    public T CreateAndAddController<T>(WindowBehaviour prefab) where T : Window
    {
        var controller = Activator.CreateInstance<T>();
        controller.InitWithParams(_game, prefab, _container);
        AddController(controller);
        return controller;
    }

    public T GetControllerByType<T>() where T : Window
    {
        foreach (var controller in _controllers)
        {
            if (controller is T)
            {
                return controller as T;
            }
        }
        return null;
    }

    private void AddController(Window controller)
    {
        controller.Init();
        _controllers.Add(controller);
    }
}
