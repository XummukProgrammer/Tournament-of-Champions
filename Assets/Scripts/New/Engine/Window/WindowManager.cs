using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager
{
    private EntryPoint _entryPoint;
    private Transform _container;
    private List<Window> _controllers = new List<Window>();

    public void Init(EntryPoint entryPoint, Transform container)
    {
        _entryPoint = entryPoint;
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
        controller.InitWithParams(_entryPoint, prefab, _container);
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
